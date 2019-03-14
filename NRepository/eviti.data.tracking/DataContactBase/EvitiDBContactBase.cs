using eviti.data.tracking.DIHelp;
using eviti.data.tracking.DomainEvent;
using eviti.data.tracking.EntityFrameworkExtensions;
using eviti.data.tracking.Interfaces;
using eviti.data.tracking.PrincipalAccessor;
using eviti.Data.Tracking.EntityFrameworkExtensions;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace eviti.data.tracking.DataContactBase
{

    public class EvitiDBContactBase : DbContext
    {


     

        private readonly IPrincipalAccessor _principalAccessor;
        public Guid MyId;

        public bool IsEvitiTrackingOn = true;

        protected IMediator _mediator { get; }

        public EvitiDBContactBase()
        {
            MyId = Guid.NewGuid();
        }
        public EvitiDBContactBase(DbContextOptions options,
            IPrincipalAccessor principalAccessor,
            IMediator mediator) : base(options)
        {
            _principalAccessor = principalAccessor;
            _mediator = mediator;
            MyId = Guid.NewGuid();
        }





        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            // This will not work if we are tracking our own changes
            //DbContextHelper.AuditUpdateChangesStandardDataContact(this.ChangeTracker, this);

            if (IsEvitiTrackingOn)
            {

            }
            var events = DbContextHelper.AuditUpdateChangeseEvitTracking(ChangeTracker, this);
            ChangeTracker.SetCreatedUpdateTimes(_principalAccessor);

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            this.AcceptChanges();

            // does this need to happen here or should this be an explicate call.
            this.DetachAllEntities();
            AuditEventsV2Generated agv2 = new AuditEventsV2Generated(events);
            // await _mediator.Publish(new OrderPlacedEvent { OrderId = Guid.NewGuid() }, cancellationToken);
            await _mediator.Publish(agv2, cancellationToken);


            return result;
        }

        public override int SaveChanges()
        {

            // This will not work if we are tracking our own changes
            //DbContextHelper.AuditUpdateChanges(this.ChangeTracker, this);

            if (IsEvitiTrackingOn)
            {

            }
            var events = DbContextHelper.AuditUpdateChangeseEvitTracking(ChangeTracker, this);
            ChangeTracker.SetCreatedUpdateTimes(_principalAccessor);
            int result = base.SaveChanges();
            this.AcceptChanges();

            // does this need to happen here or should this be an explicate call.
            this.DetachAllEntities();
            //    AuditGenerated ag = new AuditGenerated(events);
            AuditEventsV2Generated agv2 = new AuditEventsV2Generated(events);
            _mediator.Publish(agv2);
            //    DomainEvents.Raise(ag);



            return result;
        }




        internal List<object> RootObjects { get; } = new List<object>();


        public virtual void AttachAndValidate(IClientChangeTracker item)
        {

            //    GetTrackedItems();
            this.ApplyEvitiChanges(item);
            RootObjects.Add(item);
            BobValidationTest();
            ChangeTracker.Validate();


        }

        public virtual void AttachOnly(IClientChangeTracker item)
        {

            //    GetTrackedItems();
            this.ApplyEvitiChanges(item);
            //RootObjects.Add(item);
            //BobValidationTest();
            //this.ChangeTracker.Validate();


        }

        private void BobValidationTest()
        {
            var validatorFactory = ServiceLocator.GetService<IValidatorFactory>();
            foreach (var rootEntity in RootObjects)
            {
                ValidateItem(rootEntity, validatorFactory);

            }

            var entities = (from e in ChangeTracker.Entries()
                            where e.State == EntityState.Added
                                || e.State == EntityState.Modified
                            select e.Entity).ToList();



            var entities2 = (from e in ChangeTracker.Entries()
                             where e.State == EntityState.Added
                                 || e.State == EntityState.Modified
                             select e).ToList();




            var allItem = (from e in ChangeTracker.Entries() select e.Entity).ToList();
            foreach (var item2 in entities2)
            {

                ValidateItem(item2.Entity, validatorFactory);


            }
            foreach (var item in allItem)
            {


                string t = string.Empty;
            }
        }

        private ValidationResult ValidateItem(object entityToValidate, IValidatorFactory validatorFactory)
        {
            Type t1 = entityToValidate.GetType();
            //  Type t2 = item2.GetType();
            var val = validatorFactory.GetValidator(t1);
            // var val2 = validatorFactory.GetValidator(t2);

            ValidationResult valresult = null;
            if (val != null)
            {
                //https://github.com/JeremySkinner/FluentValidation/issues/361
                //https://github.com/JeremySkinner/FluentValidation/blob/master/src/FluentValidation/DefaultValidatorExtensions.cs#L835
                // this is how to pass a rule set to the validation process

                FluentValidation.ValidationContext vc;


                string ruleSet = "add";
                ruleSet = string.Empty;
                if (string.IsNullOrEmpty(ruleSet) == false)
                {
                    var ruleSetNames = ruleSet.Split(',', ';').Select(x => x.Trim());
                    IValidatorSelector selector = ValidatorOptions.ValidatorSelectors.RulesetValidatorSelectorFactory(ruleSetNames.ToArray());

                    vc = new FluentValidation.ValidationContext(entityToValidate, new PropertyChain(), selector);
                    valresult = val.Validate(vc);
                }
                else
                {
                    vc = new FluentValidation.ValidationContext(entityToValidate);
                    valresult = val.Validate(vc);

                }


                if (valresult.IsValid == false)
                {
                    string sadf = string.Empty;
                }
            }

            return valresult;
        }

        public IEnumerable<EntityEntry> GetAllTrackedItems()
        {
            return this.GetTrackedItems();
        }



        /// <summary>
        /// this can be called from the outside to reset all the tracking information
        /// It has yet to be tested when it's tracking existing items and we just want to attach, perform some update, and then detach only the items in this call.
        /// It shoudl work as it's designed but needed to be tested.  You can remove the last exception if it is tested.  if (test3.Count != 0)
        /// </summary>
        /// <param name="item"></param>
        public void ResetTrackingAndDetach(IClientChangeTracker item)
        {
            List<EntityEntry> result = this.AttacheAsUnchanged(item);

            var test2 = ChangeTracker.Entries().ToList();
            if (result.Count != test2.Count)
            {
                throw new ApplicationException("The tracked items are different that the attached items.");

                // this is not working.  I am not sure if the tracking objects are different but passing in the result does not seam to work
                // it looks like maybe comparing the equals or getting the object stage  
                //  DbContextExtensions.ResetTrackingOnEntityEntry(result);

                //   DbContextExtensions.DetachAllEntities(result);
            }

            DbContextExtensions.ResetTrackingOnEntityEntry(result);

            this.DetachAllEntities(result);


            var test3 = ChangeTracker.Entries().ToList();

            if (test3.Count != 0)
            {
                throw new ApplicationException("The tracked items should be zero unless this function is to be tested for using reset tracking when existing  objects are tracked.");
            }


            // maybe this will work?
            //foreach (var trackedItems in result)
            //{
            //    this.Entry(trackedItems.Entity).State = EntityState.Detached;
            //}



        }

        //public void ResetTracking(IClientChangeTracker item)
        //{
        //    var result = this.AttacheAsUnchanged(item);

        //    var test2 = ChangeTracker.Entries().ToList();
        //    if (result.Count != test2.Count)
        //    {
        //        throw new ApplicationException("The tracked items are different that the attached items.");
        //    }

        //    DbContextExtensions.ResetTrackingOnEntityEntry(result);

        //    DbContextExtensions.DetachAllEntities(result);

        //}




        public void DeleteAllItemsGraph(IClientChangeTracker item)
        {
            this.DeleteGraph(item);
        }

        private IDbContextTransaction _currentTransaction;

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

       


        // TO WORK OUT
        //public void TestServiceAccess()
        //{
        //    // sample of using the internal DB context
        //    var testDBContect = ((IInfrastructure<IServiceProvider>)this).GetService<ContactModelDbContext>();
        //}
        public static void ResetTrackingStatic<T>(IClientChangeTracker item) where T : EvitiDBContactBase  , new()
        {

            //using (var scope = ServiceLocator._scopeFactory.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetService<T>();

            //    dbContext.ResetTracking(item);
            //    //try
            //    //{
            //    //    //dbContext.LogMyId();
            //    //    //await dbContext.BeginTransactionAsync().ConfigureAwait(false);

            //    //    await action(scope.ServiceProvider).ConfigureAwait(false);

            //    //    //await dbContext.CommitTransactionAsync().ConfigureAwait(false);
            //    //}
            //    //catch (Exception)
            //    //{
            //    //    //dbContext.RollbackTransaction();
            //    //    throw;
            //    //}

            //}
           

            //    var ctx = new EvitiDBContactBase();
            



            T ctx = new T();
            ctx.ResetTrackingAndDetach(item);
        }

    }
}

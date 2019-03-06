using System.Transactions;
using AutoMapper;
using EvitiContact.ApplicationService.ContactModelDB.Repository;
using EvitiContact.ApplicationService.SchoolModelDB.Repository;
using EvitiContact.ContactModel;
using EvitiContact.SchoolModel;
using MediatR;

namespace EvitiContact.Service.RepositoryDB
{


    public class UnitOfWorkContactAndShoool : IUnitOfWorkContactAndShoool
    {
        private readonly ContactModelDbContext _contactDBContext;
        private readonly SchoolModelDbContext _schoolDBContext;
        private readonly IMapper _mapper;
        private IMediator _mediator { get; }

        public UnitOfWorkContactAndShoool(ContactModelDbContext contactDBContext, 
            SchoolModelDbContext schoolDBContext, 
            IMapper mapper,
             IMediator mediator)
        {
            _contactDBContext = contactDBContext;
            _schoolDBContext = schoolDBContext;
            _mediator = mediator;
            _mapper = mapper;


            // I don't like creating these without DI but like this for now. 
            Courses = new CourseRepository(_schoolDBContext);
            Contacts = new ContactReposatory(_contactDBContext);
            MDDetails = new MDMasterRepository(_contactDBContext, mapper);
        }

        public ICourseRepository Courses { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IMDMasterRepository MDDetails { get; private set; }

        public int Complete()
        {
            //https://stackoverflow.com/questions/19090860/use-of-transactionscope-with-read-uncommitted-is-with-nolock-in-sql-necessar
            //            using (var txScope = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            //            {
            //   ... The reading of records from the view is done here, through Fluent NHibernate...
            //}

            int result = 0;
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                new TransactionOptions()
                                {
                                    IsolationLevel = IsolationLevel.ReadCommitted
                                }))
            {
                result = _contactDBContext.SaveChanges();

                result = result + _schoolDBContext.SaveChanges();

                scope.Complete();
            }
            // await mediator.Publish(new Ping());
            _mediator.Publish(new EvitiContact.Service.Events.Ping());
            return result;
            // return _context.SaveChanges();
        }

        public void Dispose()
        {
            _contactDBContext.Dispose();
            _schoolDBContext.Dispose();
        }
    }
}

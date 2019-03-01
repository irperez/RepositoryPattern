using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.SchoolModel;
using MediatR;
using System;
using System.Net.NetworkInformation;
using System.Transactions;

namespace EvitiContact.Service.RepositoryDB
{
    //https://aspnetboilerplate.com/Pages/Documents/Unit-Of-Work
    //https://dotnetthoughts.net/implementing-the-repository-and-unit-of-work-patterns-in-aspnet-core/
    //https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
    //https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implemenation-entity-framework-core
    //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public interface IUnitOfWorkBase : IDisposable
    {

        int Complete();
    }

    public interface IUnitOfWorkContactAndShoool : IUnitOfWorkBase
    {
        ICourseRepository Courses { get; }
        IContactRepository Contacts { get; }
        IMDMasterRepository MDDetails { get; }
    }


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

using System;

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
}

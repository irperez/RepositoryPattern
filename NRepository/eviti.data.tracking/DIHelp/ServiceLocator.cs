using Microsoft.Extensions.DependencyInjection;
using System;

namespace eviti.data.tracking.DIHelp
{
    public sealed class Config
    {
        public int NumberOfDatabaseRetries { get; }

        public Config(int numberOfDatabaseRetries)
        {
            NumberOfDatabaseRetries = numberOfDatabaseRetries;
        }
    }

    public sealed class CommandsConnectionString
    {
        public string Value { get; }

        public CommandsConnectionString(string value)
        {
            Value = value;
        }
    }

    public sealed class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            Value = value;
        }
    }

    //   services.AddSingleton<ServiceLocatorV2 >();
    public sealed class ServiceLocatorV2
    {
        private readonly IServiceProvider _provider;

        public ServiceLocatorV2(IServiceProvider provider)
        {
            _provider = provider;
        }

        //public Result Dispatch(ICommand command)
        //{
        //    Type type = typeof(ICommandHandler<>);
        //    Type[] typeArgs = { command.GetType() };
        //    Type handlerType = type.MakeGenericType(typeArgs);

        //    dynamic handler = _provider.GetService(handlerType);
        //    Result result = handler.Handle((dynamic)command);

        //    return result;
        //}

        //public T Dispatch<T>(IQuery<T> query)
        //{
        //    Type type = typeof(IQueryHandler<,>);
        //    Type[] typeArgs = { query.GetType(), typeof(T) };
        //    Type handlerType = type.MakeGenericType(typeArgs);

        //    dynamic handler = _provider.GetService(handlerType);
        //    T result = handler.Handle((dynamic)query);

        //    return result;
        //}
    }

 



    //public class Class1
    //{
    //    public static ServiceProvider ServiceProvider;
    //}


    /// <summary>
    ///  https://dotnetcoretutorials.com/2018/05/06/servicelocator-shim-for-net-core/
    ///
    /// ALSO See This
    /// https://github.com/aspnet/DependencyInjection/issues/294
    ///
    /// AND This
    ///
    ///  using (ContactModelDbContext context = new ContactModelDbContext())
    //        {

    //            var serviceProvider = context.GetInfrastructure();
    //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
    //loggerFactory.AddProvider(new MyLoggerProvider(logs));
    /// </summary>
    public class ServiceLocator
    {
        private IServiceProvider _currentServiceProvider;
        private static IServiceProvider _serviceProvider;

        public static     IServiceScopeFactory _scopeFactory;

        //temp for testing
        private static IServiceProvider appServiceProvider;
        public static IServiceProvider AppServiceProvider { get => appServiceProvider;

            set {

                appServiceProvider = value;

                _scopeFactory = appServiceProvider.GetService<IServiceScopeFactory>();

            }

        }

        public ServiceLocator(IServiceProvider currentServiceProvider)
        {
            _currentServiceProvider = currentServiceProvider;
            AppServiceProvider = currentServiceProvider;
        }

        public static TService GetService<TService>()
        {
            return AppServiceProvider.GetService<TService>();
        }

        public static TService GetRequiredService<TService>()
        {
            return AppServiceProvider.GetRequiredService<TService>();
        }


        public static ServiceLocator Current
        {
            get
            {
                return new ServiceLocator(_serviceProvider);
            }
        }

       


        //https://github.com/aspnet/DependencyInjection/issues/294
        public static void SetLocatorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetInstance(Type serviceType)
        {
            return _currentServiceProvider.GetService(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return _currentServiceProvider.GetService<TService>();
        }
    }
}

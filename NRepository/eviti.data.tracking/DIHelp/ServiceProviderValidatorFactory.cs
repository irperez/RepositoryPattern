using FluentValidation;
using System;
namespace eviti.data.tracking.DIHelp
{
    //This is used by the .net core DI system to links up validators to models
    public class ServiceProviderValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ServiceProviderValidatorFactory()
        {
            _serviceProvider = ServiceLocator.AppServiceProvider;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _serviceProvider.GetService(validatorType) as IValidator;
        }
    }
}

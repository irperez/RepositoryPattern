using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace EvitiContact.Service
{


    // https://blog.tech-fellow.net/2018/03/24/baking-round-shaped-apps-with-mediatr/
    /// <summary>
    /// This will add the following behaviors to Mediator PipeLine.  I am just testing this as of yet 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidatorFactory _validationFactory;
        private readonly ILogger _logger;

        public ValidationBehavior(IValidatorFactory validationFactory,
                                  ILoggerFactory loggingFactory)
        {
            _validationFactory = validationFactory;
            _logger = loggingFactory.CreateLogger("ValidationBehavior");
        }

        public async Task<TResponse> Handle(TRequest request,
                                            CancellationToken cancellationToken,
                                            RequestHandlerDelegate<TResponse> next)
        {
            var validator = _validationFactory.GetValidator(request.GetType());
            var result = validator?.Validate(request);

            if (result != null && !result.IsValid)
                throw new FluentValidation.ValidationException(result.Errors);

            var response = await next();
            return response;
        }
    }


    //public class TransactionBehavior<TRequest, TResponse>
    //: IPipelineBehavior<TRequest, TResponse>
    //{
    //    private readonly SchoolContext _dbContext;

    //    public TransactionBehavior(SchoolContext dbContext) => _dbContext = dbContext;

    //    public async Task<TResponse> Handle(TRequest request,
    //        CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        try
    //        {
    //            await _dbContext.BeginTransactionAsync();
    //            var response = await next();
    //            await _dbContext.CommitTransactionAsync();
    //            return response;
    //        }
    //        catch (Exception)
    //        {
    //            _dbContext.RollbackTransaction();
    //            throw;
    //        }
    //    }
    //}

    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
            => _logger = logger;

        public async Task<TResponse> Handle(
            TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            using (_logger.BeginScope(request))
            {
                _logger.LogInformation("Calling handler...");
                var response = await next();
                _logger.LogInformation("Called handler with result {0}", response);
                return response;
            }
        }
    }

}

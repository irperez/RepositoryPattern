using EvitiContact.ContactModel;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EvitiContact.ApplicationService.Services
{
    public interface IMyTestService
    {
        void Run();
        ContactModelDbContext Ctx { get; }
    }
    public class MyTestService : IMyTestService
    {
        private readonly ILogger<MyTestService> _logger;
        private readonly IConfigurationRoot _config;
        public ContactModelDbContext Ctx { get; }
        //public MyTestService(ILogger<MyTestService> logger, IConfigurationRoot config, ContactModelDbContext ctx)
        //{
        //    _logger = logger;
        //    _config = config;
        //    Ctx = ctx;
        //}
        public MyTestService(ILogger<MyTestService> logger, ContactModelDbContext ctx)
        {
            _logger = logger;

            Ctx = ctx;
        }


        public void Run()
        {
            _logger.LogDebug($"Running backup service.");
        }
    }
}

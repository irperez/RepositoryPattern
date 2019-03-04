using System;

namespace EvitiContact.Application
{
    public class ApplicationSetup
    {
        /// <summary>
        /// Code to setup the application Domain and the service layer
        /// </summary>
        /// <param name="host"></param>
        public static void SetupApp(Microsoft.AspNetCore.Hosting.IWebHost host)
        {
            eviti.data.tracking.DIHelp.ServiceLocator.SetLocatorProvider(host.Services);
            Service.SchoolModelDB.SchoolModelDbContextSetupDB.Setup(host);
            Service.ContactModelDB.ContactModelDBSetupDB.Setup(host);
        }
    

    }
}

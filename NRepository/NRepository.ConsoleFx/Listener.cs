using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRepository.MyTestBL.BL;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace NRepository.ConsoleFx
{
    public class Listener
    {
        //This sample doesn't make a constructor where we can pass in the container...

        public Container Container { get; set; }
        
        public void HandleMessage(object message)
        {
            //Do some message handling work here

            //This requires the container has to be passed in to a listener class (via a property if needed)
            using (ThreadScopedLifestyle.BeginScope(Container))
            {
                var testProvider = Container.GetInstance<TestProvider>();

                var data = testProvider.GetPassingTests();
            }

            Console.WriteLine("Test Provider loaded successfully");
        }
    }
}

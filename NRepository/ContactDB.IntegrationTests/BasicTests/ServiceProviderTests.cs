 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ContactDB.IntegrationTests.SliceFixture; 
using MediatR;
using System.Diagnostics;
using Xunit.Abstractions;
using eviti.data.tracking.DIHelp;
using EvitiContact.ContactModel;
using EvitiContact.ApplicationService.Services;

namespace ContactDB.IntegrationTests.BasicTests
{
      
    public class ServiceProviderTests : IntegrationTestBase
    {
        // run the test and then click on the "output" link on the bottom of the task runner to see the output
        private readonly ITestOutputHelper output;

        public ServiceProviderTests(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public async Task TestScopedServiceProviderExecuteDbContextAsync()
        {
            /// This should have all different Guid IDs
            Guid one = Guid.Empty;  
            Guid two = Guid.Empty;
            Guid three = Guid.Empty;
            await ExecuteDbContextAsync(async (ctxt, mediator) =>
            {
                 one = ctxt.MyId;
            });
            await ExecuteDbContextAsync(async (ctxt, mediator) =>
            {
                two = ctxt.MyId;
            });
            await ExecuteDbContextAsync(async (ctxt, mediator) =>
            {
                three = ctxt.MyId;
            });



            output.WriteLine("TestScopedServiceProviderExecuteDbContextAsync: " + one.ToString());
            output.WriteLine("TestScopedServiceProviderExecuteDbContextAsync: " + two.ToString());
            output.WriteLine("TestScopedServiceProviderExecuteDbContextAsync: " + three.ToString());

            one.ShouldNotBeSameAs(Guid.Empty);
            three.ShouldNotBeSameAs(Guid.Empty);
            two.ShouldNotBeSameAs(Guid.Empty);

            one.ShouldBe(one);
            one.ShouldNotBe(two);
            one.ShouldNotBe(three);

            //ct1.MyId.ShouldBeSameAs(ct1.MyId);
            //ct1.MyId.ShouldNotBeSameAs(ct2.MyId);
            //ct1.ShouldBeSameAs(ct1, "This should be the same instances");
            //// this should be false
            //ct1.ShouldNotBeSameAs(ct2, "This should NOT be the same instances");
            //ct1.ShouldNotBeSameAs(ct3, "This should NOT be the same instances");
        }

        [Fact]
        public async Task TestScopedServiceProviderExecuteBobScopedServiceProfiderAsync()
        {
            /// This should have two of the same ID (one and two) and three should be a different ID
            Guid one = Guid.Empty;
            Guid two = Guid.Empty;
            Guid three = Guid.Empty;
            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                var ct1 = sp.GetService<ContactModelDbContext>();
                var ct2 = sp.GetService<ContactModelDbContext>();

                one = ct1.MyId;
                two = ct2.MyId;

            });
            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                var ct3 = sp.GetService<ContactModelDbContext>();
                three = ct3.MyId;
            });
 

            output.WriteLine("TestScopedServiceProviderExecuteBobScopedServiceProfiderAsync: " + one.ToString());
            output.WriteLine("TestScopedServiceProviderExecuteBobScopedServiceProfiderAsync: " + two.ToString());
            output.WriteLine("TestScopedServiceProviderExecuteBobScopedServiceProfiderAsync: " + three.ToString());


            one.ShouldNotBeSameAs(Guid.Empty);
            three.ShouldNotBeSameAs(Guid.Empty);
            two.ShouldNotBeSameAs(Guid.Empty);
            one.ShouldBe(one);
            one.ShouldBe(two);
            one.ShouldNotBe(three);
            //ct1.ShouldBeSameAs(ct1, "This should be the same instances");
            //// this should be false
            //ct1.ShouldNotBeSameAs(ct2, "This should NOT be the same instances");
            //ct1.ShouldNotBeSameAs(ct3, "This should NOT be the same instances");

        }

        [Fact]
        public async Task TestStaticServiceProviderV1()
        {
            //(THIS IS NOT GOOD)
            // given that this is a static Service provider and the DB context is scoped then 
            //it will elivate the instance DB context to a static instance (THIS IS NOT GOOD)

            var ct1 = ServiceLocator.GetService<IMyTestService>();
            var ct2 = ServiceLocator.GetService<IMyTestService>();
            var ct3 = ServiceLocator.GetService<IMyTestService>();

            Guid one = ct1.Ctx.MyId;
            Guid two = ct2.Ctx.MyId;
            Guid three = ct3.Ctx.MyId;
            output.WriteLine("TestStaticServiceProviderV1: " + one.ToString());
            output.WriteLine("TestStaticServiceProviderV1: " + two.ToString());
            output.WriteLine("TestStaticServiceProviderV1: " + three.ToString());
            one.ShouldBe(one);
            one.ShouldBe(two);
            one.ShouldBe(three, "This should be the same instances");
          
        }


        [Fact]
        public async Task TestStaticServiceProviderV2()
        {
            //(THIS IS NOT GOOD)
            // given that this is a static Service provider and the DB context is scoped then 
            //it will elivate the instance DB context to a static instance (THIS IS NOT GOOD)
            var ct1 = ServiceLocator.GetService<ContactModelDbContext>();
            var ct2 = ServiceLocator.GetService<ContactModelDbContext>();
            var ct3 = ServiceLocator.GetService<ContactModelDbContext>();

            Guid one = ct1.MyId;
            Guid two = ct2.MyId;
            Guid three = ct3.MyId;
            output.WriteLine("TestStaticServiceProviderV2: " + one.ToString());
            output.WriteLine("TestStaticServiceProviderV2: " + two.ToString());
            output.WriteLine("TestStaticServiceProviderV2: " + three.ToString());
            one.ShouldBe(one);
            one.ShouldBe(two);
            one.ShouldBe(three, "This should be the same instances");

        }




        //[Fact]
        //public async Task TestTheDBContactRetunedFromTheScopedServicePrividerReturnsTheCorrectInstance()
        //{
        //    Contact c = new Contact
        //    {
        //        // result.UserName = "GetNewContactUser" + " " + DateTime.Now.ToString("s");

        //        FirstName = "bob-FirstName",
        //        LastName = "bob-LastName",
        //        TypeID = 1,
        //        IsDemo = true,
        //        IsDeleted = false
        //    };
       

        //    await ExecuteDbContextAsync(async (ctxt, mediator) =>
        //    {


        //        var list = ctxt.States.ToList();
        //        string t1 = string.Empty;
        //        ctxt.AttachOnly(c);
        //        ctxt.SaveChanges();
        //        t1 = string.Empty;


        //    });

   


        //    await ExecuteDbContextBobAsync(async (ctxt, sp, mediator) =>
        //    {
        //        // I am trying to see how the DI system works with the action filters here.  I wanted to see how 
        //        // i can create test a bit more generically
        //        var ct2 = sp.GetService<ContactModelDbContext>();

        //        var ct3 = sp.GetService<ContactModelDbContext>();
        //        ct2.ShouldBeSameAs(ct2);
        //        ct2.ShouldBeSameAs(ct3,"This should be the same instances"); //   var equalresult = ct2.Equals(ct3);
                                                                 


        //        var ct4 = StaticServiceProvider.GetService<ContactModelDbContext>();
        //        // this should be false
               
        //        ct2.ShouldNotBeSameAs(ct4,  "This should NOT be the same instances");// var equalsresult2 = ct2.Equals(ct4);
                 
        //        ctxt.AttachOnly(c);
        //        ctxt.SaveChanges();
              


        //    });

        
        //}

 
    }
}

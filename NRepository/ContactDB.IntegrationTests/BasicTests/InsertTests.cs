using ContactDB.IntegrationTests.ContactDBHelpers;
 
using eviti.data.tracking.DIHelp;
using EvitiContact.ContactModel;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static ContactDB.IntegrationTests.SliceFixture;

namespace ContactDB.IntegrationTests.BasicTests
{

    public class InsertTests : IntegrationTestBase
    {


        // run the test and then click on the "output" link on the bottom of the task runner to see the output
        //https://xunit.github.io/docs/capturing-output
        private readonly ITestOutputHelper output;

        public InsertTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestContactInsertOnGlobalServiceProvider()
        {
            ContactModelDbContext dbContext = ServiceLocator.GetService<ContactModelDbContext>();

            output.WriteLine("TestContactInsertOnGlobalServiceProvider: " + dbContext.MyId.ToString());
            //  dbContext.LogMyId();
            var contact = ContactHelper.GetContactWithAddress();


            dbContext.AttachOnly(contact);
            dbContext.SaveChanges();

            contact.GUID.ShouldNotBe(Guid.Empty);
       
        }
        [Fact]
        public void TestContactUserInsertOnGlobalServiceProvider()
        {

            ContactModelDbContext dbContext = ServiceLocator.GetService<ContactModelDbContext>();
            output.WriteLine("TestContactInsertOnGlobalServiceProvider: " + dbContext.MyId.ToString());
            //  dbContext.LogMyId();
            var contactUser = ContactHelper.GetContactUserFull();


            dbContext.AttachOnly(contactUser);
            dbContext.SaveChanges();

            contactUser.UserGUID.ShouldNotBe(Guid.Empty);

        }

        [Fact]
        public async Task TestContactInsertOnScopedProvider()
        {

            var contact = ContactHelper.GetContactWithAddress();

            await InsertAsync(contact);

            contact.GUID.ShouldNotBe(Guid.Empty);

        }



        [Fact]
        public async Task TestContactInsertFullOnScopedProvider()
        {

            var contact = ContactHelper.GetContactFull();

            await InsertAsync(contact);

            contact.GUID.ShouldNotBe(Guid.Empty);

        }


        /// <summary>
        /// Testing that we can insert multiple users and pull back a single inserted User
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task TestContactUserInsertMultipleOnScopedProvider()
        {

            ContactUser testUser = ContactHelper.GetContactUserFull();
            ContactUser testUser1 = ContactHelper.GetContactUserFull();
            ContactUser testUser2 = ContactHelper.GetContactUserFull();
            await SliceFixture.ExecuteDbContextAsync(async (dbContext, mediator) =>
            {


                dbContext.AttachOnly(testUser);
                dbContext.AttachOnly(testUser1);
                dbContext.AttachOnly(testUser2);
                await dbContext.SaveChangesAsync();

            });


            ContactUser dbUser = await ContactDBHelper.GetUserFullFromDB(testUser.UserGUID);

            testUser.UserGUID.ShouldNotBe(Guid.Empty);
            testUser.UserGUID.ShouldBe(dbUser.UserGUID);

        }


        [Fact]
        public async Task TestContactUserBulkInsert()
        {

            List<Contact> TestuserList = ContactHelper.GetNewContactList(2000);

            int TotalExpected = TestuserList.Count;
            int TotalInserted = 0;

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            { 
                foreach (var item in TestuserList)
                {
                    dbContext.AttachOnly(item);

                }

                TotalInserted = await dbContext.SaveChangesAsync();

            });


            Contact dbContact = await ContactDBHelper.GetContactFullFromDB(TestuserList[0].GUID);

            dbContact.ShouldNotBeNull();

            TotalInserted.ShouldBe(TotalExpected);


        }
    }
}

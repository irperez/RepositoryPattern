using ContactDB.IntegrationTests.ContactDBHelpers;
 
using eviti.Data.Tracking.BaseObjects;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
 
using EvitiContact.ContactModel;

namespace ContactDB.IntegrationTests.BasicTests
{
    public class DeleteTests : IntegrationTestBase
    {

        [Fact]
        public async Task TestDelete()
        {
            ContactUser TestUser = await ContactDBHelper.GetInsertedContactUserFullAsync();

            int TotalAddresses = TestUser.ContactGu.ContactAddresses.Count;

            TestUser.UserName = "SaveUserWithDelete" + " " + DateTime.Now.ToString("s");
            TestUser.AccountTypeId = 3;

            var c = TestUser.ContactGu;

            c.FirstName = "SaveUserWithDelete";
            c.LastName = "SaveUserWithDelete";
            ContactAddress ca = c.ContactAddresses[0];
            ca.TrackingState = TrackingState.Deleted;
            ContactPhone cp = c.ContactPhones[0];
            cp.AreaCode = "999";

            int TotalModified = ContactTrackerHelper.GetModifiedPropertiesCount(TestUser);

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {
       
                dbContext.AttachOnly(TestUser);
                await dbContext.SaveChangesAsync();

            });


            ContactUser dbUser = await ContactDBHelper.GetUserFullFromDB(TestUser.UserGUID);

            dbUser.UserGUID.ShouldNotBe(Guid.Empty);
            dbUser.UserGUID.ShouldBe(dbUser.UserGUID);
            dbUser.ContactGu.ContactAddresses.Count.ShouldBe(TotalAddresses - 1);



        }


        [Fact]
        public async Task TestDeleteAddressOnly()
        {
            ContactUser TestUser = await ContactDBHelper.GetInsertedContactUserFullAsync();

            int TotalAddresses = TestUser.ContactGu.ContactAddresses.Count;

            ContactAddress ca = TestUser.ContactGu.ContactAddresses[0];
            ca.TrackingState = TrackingState.Deleted;

            int TotalModified = ContactTrackerHelper.GetModifiedPropertiesCount(TestUser);

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {
                dbContext.AttachOnly(TestUser);
                await dbContext.SaveChangesAsync();
            });


            ContactUser dbUser = await ContactDBHelper.GetUserFullFromDB(TestUser.UserGUID);

            dbUser.UserGUID.ShouldNotBe(Guid.Empty);
            dbUser.UserGUID.ShouldBe(dbUser.UserGUID);
            TotalModified.ShouldBe(0);
            dbUser.ContactGu.ContactAddresses.Count.ShouldBe(TotalAddresses - 1);

        }


        /// <summary>
        /// This will delete all items from the DB.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestDeleteGraph()
        {
            ContactUser TestUser = await ContactDBHelper.GetInsertedContactUserFullAsync();

            int TotalModified = ContactTrackerHelper.GetModifiedPropertiesCount(TestUser);

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {
                dbContext.DeleteAllItemsGraph(TestUser);

                await dbContext.SaveChangesAsync();
            });


            ContactUser dbUser = await ContactDBHelper.GetUserFullFromDB(TestUser.UserGUID);

            dbUser.ShouldBeNull();
        }
    }
}

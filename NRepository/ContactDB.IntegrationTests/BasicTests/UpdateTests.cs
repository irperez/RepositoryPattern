using ContactDB.IntegrationTests.ContactDBHelpers;
using EvitiContact.ContactModel;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;


namespace ContactDB.IntegrationTests.BasicTests
{

    public class UpdateTests : IntegrationTestBase
    {

        [Fact]
        public async Task UpdateTest()
        {
            ContactUser TestUser = await ContactDBHelper.GetInsertedContactUserFullAsync();

            int TotalAddresses = TestUser.ContactGu.ContactAddresses.Count;

            TestUser.UserName = "UpdateTest" + " " + DateTime.Now.ToString("s");
            TestUser.AccountTypeId = 3;

            var c = TestUser.ContactGu;

            c.FirstName = "UpdateTest-FNAME";
            c.LastName = "UpdateTest-FNAME";
            ContactPhone cp = c.ContactPhones[0];
            cp.AreaCode = "999";
            int TotalModifiedBeForAdd = ContactTrackerHelper.GetModifiedPropertiesCount(TestUser);

            c.ContactAddresses.Add(ContactHelper.GetAddress());


            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {

                dbContext.AttachOnly(TestUser);
                await dbContext.SaveChangesAsync();

            });


            ContactUser dbUser = await ContactDBHelper.GetUserFullFromDB(TestUser.UserGUID);
            TotalModifiedBeForAdd.ShouldBe(5);
            dbUser.UserGUID.ShouldNotBe(Guid.Empty);
            dbUser.UserGUID.ShouldBe(dbUser.UserGUID);
            dbUser.ContactGu.ContactAddresses.Count.ShouldBe(TotalAddresses + 1);
             
        }
    }
}

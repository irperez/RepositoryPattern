using ContactDB.IntegrationTests.ContactDBHelpers;
 
using eviti.data.tracking.DataContactBase;
using EvitiContact.ContactModel;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static ContactDB.IntegrationTests.SliceFixture;
namespace ContactDB.IntegrationTests.BasicTests
{
    public class TrackingTests : IntegrationTestBase
    {  // run the test and then click on the "output" link on the bottom of the task runner to see the output
        //https://xunit.github.io/docs/capturing-output
        private readonly ITestOutputHelper output;

        public TrackingTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public async Task InsertingDummyRecords()
        {
            ContactUser user = await ContactDBHelper.GetInsertedContactUserFullAsync();
            user = await ContactDBHelper.GetInsertedContactUserFullAsync();
            user = await ContactDBHelper.GetInsertedContactUserFullAsync();
            user = await ContactDBHelper.GetInsertedContactUserFullAsync();
            user = await ContactDBHelper.GetInsertedContactUserFullAsync();
            user = await ContactDBHelper.GetInsertedContactUserFullAsync();
        }

        [Fact]
        public async Task TestResetTracking()
        {
            ContactUser user = await ContactDBHelper.GetInsertedContactUserFullAsync();


            user.UserName = "bob";
            user.ContactGu.FirstName = "bob";
            user.ContactGu.LastName = "Godfrey";

            int TrackedCountOrginal = ContactTrackerHelper.GetModifiedPropertiesCount(user);


            EvitiDBContactBase.ResetTrackingStatic<ContactModelDbContext>(user);


            int TrackedCountAfterReset = user.ContactGu.ModifiedProperties.Count + user.ModifiedProperties.Count;

            TrackedCountOrginal.ShouldBe(3);// should be 3 items after the updates
            TrackedCountAfterReset.ShouldBe(0);


        }


        /// <summary>
        /// Validate that we can just update a portion of the Entity 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestThatWeCanDoAPartialUpdate()
        {
            //Arange
            ContactUser existingUser = await ContactDBHelper.GetInsertedContactUserFullAsync();

            // Act
            string Comment = "MyTestComment";
            var newObjectForExitingUser = new ContactUser
            {
                UserGUID = existingUser.UserGUID,
                Comment = Comment,
                TSStamp = existingUser.TSStamp
            };

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();

                contect.AttachAndValidate(newObjectForExitingUser);
                await contect.SaveChangesAsync();

            });
            //Assert
            var contactUserFromDB = await FindAsync<ContactUser>(existingUser.UserGUID);
            contactUserFromDB.ShouldNotBeNull();
            contactUserFromDB.GUID.ShouldBe(existingUser.GUID);

            contactUserFromDB.Comment.ShouldBe(Comment);
        }
    }
}

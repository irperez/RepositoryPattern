using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using EvitiContact.ContactModel;
namespace ContactDB.IntegrationTests.ContactDBHelpers
{

    public class ContactDBHelper
    {

        public static async Task<Contact> GetInsertedContactFull()
        {
            Contact contact = ContactHelper.GetContactFull();
            await SliceFixture.ExecuteDbContextAsync(async (dbContext, mediator) =>
            {
                //   dbContext.LogMyId();
                dbContext.AttachOnly(contact);
                await dbContext.SaveChangesAsync();
            });


            return contact;


        }

        public static async Task<ContactUser> GetInsertedContactUserFullAsync()
        {
            ContactUser user = ContactHelper.GetContactUserFull();

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {
                dbContext.AttachOnly(user);
                await dbContext.SaveChangesAsync();

            });
            return user;

        }





        public static async Task<Contact> GetInsertedContactFullAsync()
        {
            Contact contact = ContactHelper.GetContactFull();

            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {
                //var message = new DiagnosticMessage("TestContactInsertOnGlobalServiceProvider: " + dbContext.MyId.ToString());
                //diagnosticMessageSink.OnMessage(message);

                //   dbContext.LogMyId();
                dbContext.AttachOnly(contact);
                dbContext.SaveChanges();

            });
            return contact;

        }
        public static async Task<ContactUser> GetUserFullFromDB(Guid userGuid)
        {
            ContactUser cu = null;
            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {

                //https://github.com/aspnet/EntityFrameworkCore/issues/4716
                cu = await (from x in dbContext.ContactUser
                        .Include(p => p.ContactGu).ThenInclude(x => x.ContactAddresses)
                        .Include(p => p.ContactGu).ThenInclude(x => x.ContactPhones)
                        .Include(p => p.ContactGu).ThenInclude(x => x.ContactEmails)
                            where x.UserGUID == userGuid
                            select x).FirstOrDefaultAsync();

            });
            return cu;


        }

        public static async Task<Contact> GetContactFullFromDB(Guid contactGuid)
        {
            Contact contact = null;
            await SliceFixture.ExecuteBobScopedServiceProfiderAndContactDBContextAsync(async (sp, dbContext) =>
            {

                //https://github.com/aspnet/EntityFrameworkCore/issues/4716
                contact = await (from x in dbContext.Contact
                         .Include(x => x.ContactAddresses)
                         .Include(x => x.ContactPhones)
                         .Include(x => x.ContactEmails)
                            where x.GUID == contactGuid
                            select x).FirstOrDefaultAsync();

            });
            return contact;


        }

    }

}

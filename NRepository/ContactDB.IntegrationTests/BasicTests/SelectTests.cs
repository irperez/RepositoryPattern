using ContactDB.IntegrationTests.ContactDBHelpers;
using EvitiContact.ContactModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using Xunit.Abstractions;
 
using static ContactDB.IntegrationTests.SliceFixture;
 
namespace ContactDB.IntegrationTests.BasicTests
{


    


    /// <summary>
    /// the issue with teh select SQL contact is that i am checking for a contents of a list.  
    /// Given that  other test can insert records, and respawn only runs at the beginning of each test. 
    /// </summary>
    [CollectionDefinition("Timeout Tests", DisableParallelization = true)]
    public class SelectTests : IntegrationTestBase // ,IDisposable
    {




        // run the test and then click on the "output" link on the bottom of the task runner to see the output
        //https://xunit.github.io/docs/capturing-output
        private readonly ITestOutputHelper output;

        private readonly ILogger<SelectTests> _logger;

        public SelectTests(ITestOutputHelper testOutputHelper)
        {

            output = testOutputHelper;
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<SelectTests>();


        }

        //public void Dispose()
        //{
        //    ResetCheckpointSync();
        //}

        [Fact]
        public async Task SelectContactById()
        {
            var contactInserted = await ContactDBHelper.GetInsertedContactFullAsync();


            var contact = await FindAsync<Contact>(contactInserted.GUID);
            contact.ShouldNotBeNull();
            contact.GUID.ShouldBe(contactInserted.GUID);

        }




        [Fact]
        public async Task PartialSelectUser()
        {
            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();
            ContactUser contactUser = null;

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
                contactUser = await contect.ContactUser.Where(x => x.UserGUID == cu.UserGUID)
                   .Select(x => new ContactUser
                   {
                       UserGUID = x.UserGUID,
                       // UserName = x.UserName,
                       ContactGu = x.ContactGu,
                       // ContactGu = x.ContactGu.ContactAddresses.Select(a => new ContactAddress  {  GUID = a.GUID,   City = a.City,   }).ToList(),

                   })
                  .FirstOrDefaultAsync();
            });

            contactUser.ShouldNotBeNull();
            contactUser.UserGUID.ShouldBe(cu.UserGUID);

            contactUser.UserName.ShouldBeNull();

            contactUser.ContactGu.FirstName.ShouldNotBeNullOrWhiteSpace();


        }

        /// <summary>
        /// Test that we can pull an anonymous type from the DB context
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PartialSelectUserAnonymousType()
        {
            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();

            Guid UserGUID = Guid.Empty;
            string FirstName = string.Empty;
            string LastName = string.Empty;
            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
                var test = await contect.ContactUser.Where(x => x.UserGUID == cu.UserGUID)
                   .Select(x => new
                   {
                       x.UserGUID,
                       // UserName = x.UserName,
                       //  ContactGu = x.ContactGu,
                       x.ContactGu.FirstName,
                       x.ContactGu.LastName,
                       LastNameSomeThingNew = x.ContactGu.LastName,
                       // ContactGu = x.ContactGu.ContactAddresses.Select(a => new ContactAddress  {  GUID = a.GUID,   City = a.City,   }).ToList(),

                   })
                  .FirstOrDefaultAsync();

                UserGUID = test.UserGUID;
                FirstName = test.FirstName;
                LastName = test.LastName;
            });

            UserGUID.ShouldBe(cu.UserGUID);
            FirstName.ShouldNotBeNullOrWhiteSpace();
            LastName.ShouldNotBeNullOrWhiteSpace();

        }

        [Fact]
        public async Task PartialSelectContact()
        {
            Contact contactInserted = await ContactDBHelper.GetInsertedContactFullAsync();

            Contact contact = null;

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext contect = sp.GetRequiredService<ContactModelDbContext>();
                contact = contect.Contact.Where(x => x.GUID == contactInserted.GUID)
                 .Select(x => new Contact
                 {
                     GUID = x.GUID,
                     FirstName = x.FirstName,
                     // ContactAddresses = x.ContactAddresses.Where(c => c.Age >= 5),
                     ContactAddresses = x.ContactAddresses.Select(a => new ContactAddress
                     {
                         GUID = a.GUID,
                         City = a.City,
                     }).ToList(),

                 })

                 .FirstOrDefault();

            });

            contact.ShouldNotBeNull();
            contact.GUID.ShouldBe(contactInserted.GUID);
            contact.FirstName.ShouldNotBeNull();
            contact.LastName.ShouldBeNull();

            contact.ContactAddresses.Count.ShouldBe(1);
            contact.ContactAddresses[0].Street.ShouldBeNull();
            contact.ContactAddresses[0].City.ShouldNotBeNull();
        }



        [Fact]
        public async Task PartialSelectSQLContact()
        {

            ContactUser contactUserInserted = await ContactDBHelper.GetInsertedContactUserFullAsync();
            ContactUser partialContact = null;
            List<EntityEntry> tracktedItems = null;

            //await ExecuteDbContextAsync(async (db, mediator) =>
            //{

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
          {
              ContactModelDbContext db = sp.GetRequiredService<ContactModelDbContext>();

              tracktedItems = db.ChangeTracker.Entries().ToList();

              using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
              {
                  partialContact = await db.ContactUser.Select(r => new ContactUser { UserGUID = r.UserGUID, TSStamp = r.TSStamp, Comment = r.Comment })
                  .Where(x => x.UserGUID == contactUserInserted.UserGUID).FirstOrDefaultAsync();
                  scope.Complete();
              }
              //partialSelectSQLList = db.ContactUser.FromSql("select * from contactuser").ToList();

              //var test = db.Model.GetChangeTrackingStrategy();

              //var test2 = db.Model.SqlServer().ValueGenerationStrategy;

              //var test3 = db.Model.GetPropertyAccessMode();

              //var test4 = db.Model.GetAnnotations().ToList();

              //var test5 = db.Model.GetEntityTypes().ToList();


          });

            tracktedItems.Count.ShouldBe(0);
            partialContact.ShouldNotBeNull();
            //partialContact.Count.ShouldBe(1);
            partialContact.UserGUID.ShouldBe(contactUserInserted.UserGUID);


            //partialSelectSQLList.ShouldNotBeNull();
            //partialSelectSQLList.Count.ShouldBe(1);
            //partialSelectSQLList[0].UserGUID.ShouldBe(contactUserInserted.UserGUID);


        }



    }



}

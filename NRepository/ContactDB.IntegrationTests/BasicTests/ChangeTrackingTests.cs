using ContactDB.IntegrationTests.ContactDBHelpers;
using EvitiContact.ContactModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
 
using static ContactDB.IntegrationTests.SliceFixture;
 
namespace ContactDB.IntegrationTests.BasicTests
{
    public class ChangeTrackingTests : IntegrationTestBase
    {

        [Fact]
        public async Task StandardConfigTrackedAllItems()
        {
            List<ContactUser> users = null;
            List<States> states = null;
            List<EntityEntry> tracktedItems = null;
            using (var db = ContactModelDbContext.DBFactory())
            {
                states = db.States.ToList();

                tracktedItems = db.ChangeTracker.Entries().ToList();
                // _logger.LogInformation($"Total Tracked Items for TrackedTest0 {tracktedItems.Count}");


            }
            states.ShouldNotBeNull();
            tracktedItems.ShouldNotBeNull();

            tracktedItems.Count.ShouldBe(states.Count);

            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext context = sp.GetRequiredService<ContactModelDbContext>();


                states = context.States.ToList();

                tracktedItems = context.ChangeTracker.Entries().ToList();


                ContactModelDbContext context2 = sp.GetRequiredService<ContactModelDbContext>();

                users = context.ContactUser.ToList();

                tracktedItems = context.ChangeTracker.Entries().ToList();

            });



            states.ShouldNotBeNull();
            tracktedItems.ShouldNotBeNull();
            int TotalCount = states.Count + users.Count;
            tracktedItems.Count.ShouldBe(TotalCount);
        }

        [Fact]
        public async Task StandardConfigNoTrackingSetOnDBContext()
        {

            List<ContactUser> users = null;
            List<States> states = null;
            List<EntityEntry> tracktedItems = null;



            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext context = sp.GetRequiredService<ContactModelDbContext>();
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                states = context.States.ToList();

                tracktedItems = context.ChangeTracker.Entries().ToList();


                ContactModelDbContext context2 = sp.GetRequiredService<ContactModelDbContext>();

                users = context.ContactUser.ToList();

                tracktedItems = context2.ChangeTracker.Entries().ToList();

            });

            states.ShouldNotBeNull();
            tracktedItems.ShouldNotBeNull();
            int TotalCount = users.Count;
            tracktedItems.Count.ShouldBe(0);

        }



        [Fact]
        public async Task StandardNoTrackingQuery()
        {
            List<States> states = null;
            List<EntityEntry> tracktedItems = null;



            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext context = sp.GetRequiredService<ContactModelDbContext>();

                states = context.States.AsNoTracking().ToList();


                tracktedItems = context.ChangeTracker.Entries().ToList();


                //ContactModelDbContext context2 = sp.GetRequiredService<ContactModelDbContext>();

                //users = context.ContactUser.ToList();

                //tracktedItems = context.ChangeTracker.Entries().ToList();

            });

            states.ShouldNotBeNull();
            tracktedItems.ShouldNotBeNull();
            tracktedItems.Count.ShouldBe(0);
        }




        [Fact]
        public async Task NoTrackingQueryWithChildTracked()
        {
            List<States> states = null;
            List<EntityEntry> tracktedItems2 = null;
            List<ZipCodes> zipCodes = null;
            List<EntityEntry> tracktedItems1 = null;

            ContactUser cu = await ContactDBHelper.GetInsertedContactUserFullAsync();


            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext context = sp.GetRequiredService<ContactModelDbContext>();

                states = context.States.AsNoTracking().ToList();



                //ContactModelDbContext context2 = sp.GetRequiredService<ContactModelDbContext>();

                //users = context.ContactUser.ToList();

                tracktedItems1 = context.ChangeTracker.Entries().ToList();



                var delaware = states.Where(x => x.Name.Contains("Dela")).FirstOrDefault();


                ContactModelDbContext context2 = sp.GetRequiredService<ContactModelDbContext>();

                zipCodes = context2.ZipCodes.Where(x => x.StateCode == delaware.StateCode).ToList();
                tracktedItems2 = context2.ChangeTracker.Entries().ToList();


            });

            states.ShouldNotBeNull();
            tracktedItems1.ShouldNotBeNull();
            tracktedItems2.ShouldNotBeNull();
            zipCodes.ShouldNotBeNull();
            tracktedItems1.Count.ShouldBe(0);
            tracktedItems2.Count.ShouldBe(zipCodes.Count);
        }




        [Fact]
        public async Task TrackedItemsOnDBContext()
        {
            List<States> states = null;
            States Delaware = null;
            List<EntityEntry> trackedItemsShouldBe99 = null;
            List<ZipCodes> zipCodes = null;
            List<EntityEntry> tracktedItems1 = null;
            bool isDirty;
            List<EntityEntry> detatchedTotalShouldBeZero = null;
            List<EntityEntry> changedEntriesCopy = null;

            await ExecuteBobScopedServiceProfiderAsync(async (sp) =>
            {
                ContactModelDbContext db = sp.GetRequiredService<ContactModelDbContext>();


                states = db.States.AsNoTracking().ToList();
                Delaware = states.Where(x => x.Name.Contains("Dela")).FirstOrDefault();

                zipCodes = db.ZipCodes.Where(x => x.StateCode == Delaware.StateCode).ToList();

                tracktedItems1 = db.ChangeTracker.Entries().ToList();
                // _logger.LogInformation($"Total Tracked Items for TrackedTest5 {tracktedItems.Count}");

                //db.ChangeTracker.TrackGraph(item, node =>
                //{
                //    node.Entry.State = EntityState.Detached;

                //});
                var zip19707 = zipCodes.Where(x => x.ZipCode == "19707").FirstOrDefault();
                zip19707.City = "bobHockessin";

                isDirty = db.ChangeTracker.HasChanges();
                // _logger.LogInformation($"TrackedTest5 isDirty {isDirty}");


                changedEntriesCopy = db.ChangeTracker.Entries()
              .Where(e => e.State == EntityState.Added ||
                          e.State == EntityState.Modified ||
                          e.State == EntityState.Deleted)
              .ToList();
                //  _logger.LogInformation($"Total Tracked CHANGED Items for TrackedTest5 {changedEntriesCopy.Count}");

                foreach (var entry in changedEntriesCopy)
                {
                    entry.State = EntityState.Detached;
                }



                trackedItemsShouldBe99 = db.ChangeTracker.Entries().ToList();
                //_logger.LogInformation($"Total Tracked  Items for TrackedTest5-tracktedItems2 {tracktedItems2.Count}");

                var allItems = db.ChangeTracker.Entries()
            //.Where(e => e.State == EntityState.Added ||
            //            e.State == EntityState.Modified ||
            //            e.State == EntityState.Deleted)
            .ToList();

                foreach (var entry in allItems)
                {
                    entry.State = EntityState.Detached;
                }


                detatchedTotalShouldBeZero = db.ChangeTracker.Entries().ToList();
                //   _logger.LogInformation($"Total Tracked  Items for TrackedTest5-detatchedTotalShouldBeZero {detatchedTotalShouldBeZero.Count}");

            });

            detatchedTotalShouldBeZero.Count.ShouldBe(0);
            trackedItemsShouldBe99.Count.ShouldBe(99);
        }
    }
}

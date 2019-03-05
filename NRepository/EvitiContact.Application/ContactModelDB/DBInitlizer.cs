using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Service.BulkProcess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EvitiContact.Service.ContactModelDB
{
    public static class DbInitializer
    {
        public static void Initialize(ContactModelDbContext context, IMapper mapper)
        {
            //context.Database.EnsureCreated();

            // Look for any states.
            if (context.States.Any() == false)
            {
                var states = EntityJsonMapper.GetStatesFromJSON(mapper);
                foreach (var item in states)
                {
                    context.Add(item);
                }
                context.SaveChanges();
            }
            if (context.ZipCodes.Any() == false)
            {
                var connectionString = context.Database.GetDbConnection().ConnectionString;
                ZipCodes[] zips = EntityJsonMapper.GetZipsFromJSON(mapper);
                BulkInsert.BulkInsertZips(zips, connectionString);
            }

            if (context.MDMaster.Any() == false)
            {
                context.AttachOnly(MasterDetailHelper.GetMasterTestObjext());
                int result = context.SaveChanges();
            }

            if (context.ContactType.Any() == false)
            {
                var states = EntityJsonMapper.GetContactTypeFromJSON(mapper);
                foreach (var item in states)
                {
                    context.Add(item);
                }
                context.SaveChanges();
            }

            //context.SaveChanges();
            return;   // DB has been seeded

        }
    }
}

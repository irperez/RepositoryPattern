using eviti.data.tracking.Interfaces;
using eviti.data.tracking.PrincipalAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eviti.data.tracking.EntityFrameworkExtensions
{



    public static class DbContextHelper
    {

        public static void AddOnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<SamuraiBattle>()
            //  .HasKey(s => new { s.BattleId, s.SamuraiId });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            }
        }


        //public static object GetPrimaryKeyValue(EntityEntry entry, DbContext db)
        //{

        //    entry.fin
        //    var objectStateEntry = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);


        //    return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        //}

        private static string GetPrimaryKeyAsString(DbContext db, EntityEntry change)
        {

            string PKValue = string.Empty;

            try
            {
                var primaryKey = GetPrimaryKeyValue(change, db);
                PKValue = primaryKey.ToString();

            }
            catch (Exception ex) { string msg = ex.Message; }

            return PKValue;
        }
        public static object GetPrimaryKeyValue(EntityEntry entity, DbContext db)
        {


            //var t = entity.Entity.GetType().FullName;
            //var Mytpe = db.Model.FindEntityType(t);
            //var myKey = db.Model.FindEntityType(t).FindPrimaryKey();

            //var keyName = db.Model.FindEntityType(t).FindPrimaryKey().Properties.Select(x => x.Name).Single();

            //return entity.GetType().GetProperty(keyName).GetValue(entity, null);


            //https://blogs.msmvps.com/ricardoperes/2016/02/22/implementing-missing-features-in-entity-framework-core/
            var key = entity.Metadata.FindPrimaryKey();

            var props = key.Properties.ToArray();

            var valueArray = props.Select(x => x.GetGetter().GetClrValue(entity.Entity)).ToArray();
            return valueArray[0];
      
            //var keyName = key.Properties.Select(x => x.Name).Single();

            //var asdfsadf = entity.CurrentValues.Properties["asf"];
            //var temp = entity.GetType().GetProperty(keyName) ;

            //var result = temp.GetValue(entity);

            //  result = entity.GetType().GetProperty(keyName).GetValue(entity, null);
            //return result;



        }


        //public static void SetKeys(EntityEntry entry)
        //{

        //    if (entry.IsKeySet)
        //    {
        //        if (((ClientChangeTracker)entry.Entity).IsDirty)
        //        {
        //            entry.State = EntityState.Modified;
        //        }
        //        else
        //        {
        //            entry.State = EntityState.Unchanged;
        //        }
        //    }
        //    else
        //    {
        //        entry.State = EntityState.Added;
        //    }
        //}

        //object GetPrimaryKeyValue(DbEntityEntry entry)
        //{
        //    var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        //    return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        //}



        public static void Validate(this ChangeTracker ChangeTracker)
        {
            var entities = (from e in ChangeTracker.Entries()
                            where e.State == EntityState.Added
                                || e.State == EntityState.Modified
                            select e.Entity).ToList();

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }
        }

        public static void SetCreatedUpdateTimes(this ChangeTracker ChangeTracker, IPrincipalAccessor principalAccessor)
        {
            var now = DateTime.UtcNow;

            //https://stackoverflow.com/questions/26355486/entity-framework-6-audit-track-changes
            //https://stackoverflow.com/questions/26355486/entity-framework-6-audit-track-changes
            var addedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
            .Where(p => p.State == EntityState.Added)
            .Select(p => p.Entity).ToList();

            //var modifiedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
            //  .Where(p => p.State == EntityState.Modified || p.State == EntityState.Unchanged)
            //  .Select(p => p.Entity);
            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
                        .Where(p => p.State == EntityState.Modified)
                        .Select(p => p.Entity).ToList();

            // var now2 = DateTime.UtcNow;
            string username = principalAccessor.Username; // "bob"; //myUser.GetPrincipalUser().UserName; // "bob"           
            foreach (var added in addedAuditedEntities)
            {
                added.CreatedDate = now;
                added.CreatedBy = username;
                added.ModifiedDate = added.CreatedDate;
                added.ModifiedBy = added.CreatedBy;
                added.Version = "2.0";



            }

            foreach (var modified in modifiedAuditedEntities)
            {
                //var t = modified as ClientChangeTracker;
                //if (t != null && t.IsDirty == true)
                //{
                modified.ModifiedDate = now;
                modified.ModifiedBy = username;

                // }

            }


            //C:\bobgodfrey.visualstudio.com\Default\EFCore\NetCoreSolutionToMigrateToVS2017-master\src\SamuraiAppCore.Data
            //foreach (var entry in ChangeTracker.Entries()
            // .Where(e => e.State == EntityState.Added ||
            //             e.State == EntityState.Modified))
            //{
            //    entry.Property("LastModified").CurrentValue = DateTime.Now;
            //}

        }


        //private void EFtutorialAudit()
        //{
        //    //http://www.entityframeworktutorial.net/EntityFramework4.3/dbentityentry.aspx

        //    using (var dbCtx = new SchoolDBEntities())
        //    {
        //        //get student whose StudentId is 1
        //        var student = dbCtx.Students.Find(1);

        //        //edit student name
        //        student.StudentName = "Edited name";

        //        //get DbEntityEntry object for student entity object
        //        var entry = dbCtx.Entry(student);

        //        //get entity information e.g. full name
        //        Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);

        //        //get current EntityState
        //        Console.WriteLine("Entity State: {0}", entry.State);

        //        Console.WriteLine("********Property Values********");

        //        foreach (var propertyName in entry.CurrentValues.PropertyNames)
        //        {
        //            Console.WriteLine("Property Name: {0}", propertyName);

        //            //get original value
        //            var orgVal = entry.OriginalValues[propertyName];
        //            Console.WriteLine("     Original Value: {0}", orgVal);

        //            //get current values
        //            var curVal = entry.CurrentValues[propertyName];
        //            Console.WriteLine("     Current Value: {0}", curVal);
        //        }

        //    }
        //}

        //

        //public static void SetKeys(ChangeTracker ChangeTracker, DbContext db)
        //{

        //    var added = ChangeTracker.Entries()
        //       .Where(p => p.State == EntityState.Added).ToList();


        //    var allChanges = ChangeTracker.Entries()
        //      .Where(p => p.State != EntityState.Deleted).ToList();




        //    foreach (var item in allChanges)
        //    {

        //        if (item.IsKeySet==false )
        //        {
        //            string t = string.Empty;

        //        }
        //        IPKEntity id = item.Entity as IPKEntity;

        //        if (id != null)
        //        {
        //            if (id.Id == Guid.Empty)
        //            {
        //                //   https://docs.microsoft.com/en-us/ef/core/saving/explicit-values-generated-properties
        //                //https://docs.microsoft.com/en-us/ef/core/modeling/generated-properties
        //                // id.Id = Guid.NewGuid();
        //                item.State = EntityState.Added;
        //            }
        //            //else
        //            //{
        //            //    item.State = EntityState.Modified;
        //            //}
        //        }


        //        //if (entry.IsKeySet)
        //        //{
        //        //    if (((ClientChangeTracker)entry.Entity).IsDirty)
        //        //    {
        //        //        entry.State = EntityState.Modified;
        //        //    }
        //        //    else
        //        //    {
        //        //        entry.State = EntityState.Unchanged;
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    entry.State = EntityState.Added;
        //        //}
        //    }

        //    foreach (var addedItem in added)
        //    {
        //        // this seams to be the easiest right now.  Just define an interface, check all added items and then add keys  
        //        IPKEntity id = addedItem.Entity as IPKEntity;

        //        if (id != null)
        //        {

        //            if (id.Id == Guid.Empty)
        //            {
        //                id.Id = Guid.NewGuid();
        //            }
        //        }

        //        //if (addedItem.IsKeySet==false)
        //        //{
        //        //try
        //        //{
        //        //   var asdfsadf =   addedItem.GetPrimaryKey(db);

        //        //    var primaryKey = GetPrimaryKeyValue(addedItem, db);
        //        //    var PKValue = primaryKey.ToString();

        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    string exmsg = ex.Message;
        //        //    //   Exception ex

        //        //}

        //    }

        //    //}


        //}
        /// <summary>
        ///  This only works when you have the EF change tracker on.  
        ///  For example, Attach your object(s), update your object(s), and call save
        /// </summary>
        /// <param name="ChangeTracker"></param>
        /// <param name="db"></param>
        public static List<ChangeLog> AuditUpdateChangesStandardDataContact(ChangeTracker ChangeTracker, DbContext db)
        {
       // https://www.exceptionnotfound.net/entity-change-tracking-using-dbcontext-in-entity-framework-6/

            //  var allEntities = ChangeTracker.Entries()
            //.ToList();

            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified).ToList();



            //          if (1==0)
            //          {
            //modifiedEntities = allEntities;
            //          }


            var now = DateTime.UtcNow;
            // need to save this  to the DB contexts
            List<ChangeLog> ChangeLogs = new List<ChangeLog>();

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;

                string PKValue = GetPrimaryKeyAsString(db, change);
                 
                foreach (var prop in change.OriginalValues.Properties)
                {

                    string originalValue = string.Empty;
                    if (change.OriginalValues[prop] != null)
                    {
                        originalValue = change.OriginalValues[prop].ToString();
                    }


                    string currentValue = string.Empty;
                    if (change.CurrentValues[prop] != null)
                    {
                        currentValue = change.CurrentValues[prop].ToString();
                    }
                    if (prop.Name.Equals("Comment"))
                    {
                        string tasfdt = string.Empty;
                    }

                    if (originalValue != currentValue)
                    {
                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = PKValue,
                            PropertyName = prop.Name,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };
                        ChangeLogs.Add(log);
                    }
                }
            }

            string t = string.Empty;

            return ChangeLogs;
        }




        /// <summary>
        ///  This only works with the eviti tracked objects
        ///   
        /// </summary>
        /// <param name="ChangeTracker"></param>
        /// <param name="db"></param>
        public static List<ChangeLog> AuditUpdateChangeseEvitTracking(ChangeTracker ChangeTracker, DbContext db)
        {
            // https://www.exceptionnotfound.net/entity-change-tracking-using-dbcontext-in-entity-framework-6/
             
            //var modifiedEntities = ChangeTracker.Entries()
            //    .Where(p => p.State == EntityState.Modified).ToList();


            var changedEntities = ChangeTracker.Entries()
             .Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted)
             .ToList();
             
            // need to save this to the DB contexts
            List<ChangeLog> ChangeLogs = new List<ChangeLog>();
            if (changedEntities.Count == 0) { return ChangeLogs; }

            var now = DateTime.UtcNow;
            foreach (EntityEntry change in changedEntities)
            {
                 
                var mytrackedObjext = change.Entity as IClientChangeTracker;

                if (mytrackedObjext is null) { continue; }
                 
                var entityName = change.Entity.GetType().Name;

                string PKValue = GetPrimaryKeyAsString(db, change);

                if (change.State==EntityState.Modified)
                {

                    foreach (string propName in mytrackedObjext.ModifiedProperties)
                    {
                        string currentValue = string.Empty;
                        if (change.CurrentValues[propName] != null)
                        {
                            currentValue = change.CurrentValues[propName].ToString();
                        }

                        string originalValue = string.Empty;
                        if (change.OriginalValues[propName] != null)
                        {
                            originalValue = change.OriginalValues[propName].ToString();
                        }

                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = PKValue,
                            PropertyName = propName,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now,
                            EntityState = change.State.ToString()
                        };
                        ChangeLogs.Add(log);
                    }
                }
                else if (change.State == EntityState.Deleted)
                {
                    ChangeLog log = new ChangeLog()
                    {
                        EntityName = entityName,
                        PrimaryKeyValue = PKValue,
                        //PropertyName = propName,
                        //OldValue = originalValue,
                        //NewValue = currentValue,
                        DateChanged = now,
                        EntityState = change.State.ToString()
                    };
                    ChangeLogs.Add(log);
                }
                else if (change.State == EntityState.Added)
                {
                    foreach (var prop in change.OriginalValues.Properties)
                    { 
                        string originalValue = string.Empty;
                        if (change.OriginalValues[prop] != null)
                        {
                            originalValue = change.OriginalValues[prop].ToString();
                        }


                        string currentValue = string.Empty;
                        if (change.CurrentValues[prop] != null)
                        {
                            currentValue = change.CurrentValues[prop].ToString();
                        }
                       
                         
                            ChangeLog log = new ChangeLog()
                            {
                                EntityName = entityName,
                                PrimaryKeyValue = PKValue,
                                PropertyName = prop.Name,
                                OldValue = originalValue,
                                NewValue = currentValue,
                                DateChanged = now,
                                EntityState = change.State.ToString()
                            };
                            ChangeLogs.Add(log);
                        
                    }
                }



            }

            string t = string.Empty;

            return ChangeLogs;
        }
    }
}

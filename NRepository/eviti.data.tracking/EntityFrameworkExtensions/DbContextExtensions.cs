using eviti.data.tracking.Interfaces;
using eviti.Data.Tracking.BaseObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace eviti.Data.Tracking.EntityFrameworkExtensions
{
    public static class DbContextExtensions
    {


        /// <summary>
        /// This is primarily used to attach and then get the object graph for other functions so they can itterate over them
        /// </summary>
        /// <param name="context"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<EntityEntry> AttacheAsUnchanged(this DbContext context, IClientChangeTracker item)
        {

            List<EntityEntry> AttachedItems = new List<EntityEntry>();

            string t = string.Empty;

            context.ChangeTracker.TrackGraph(item, node =>
            {
                var subItem = node.Entry.Entity;

                if (!(node.Entry.Entity is IClientChangeTracker trackable))
                {

                    return;
                }
                node.Entry.State = EntityState.Unchanged;


                AttachedItems.Add(node.Entry);


            });


            return AttachedItems;



        }

        public static void ApplyEvitiChanges(this DbContext context, IEnumerable<IClientChangeTracker> items)
        {
            // Apply changes to collection of items
            foreach (var item in items)
            {
                context.ApplyEvitiChanges(item);
            }

        }

        /// <summary>
        /// Update entity state on DbContext for an object graph.
        /// </summary>
        /// <param name="context">Used to query and save changes to a database</param>
        /// <param name="item">Object that implements ITrackable</param>
        public static List<IClientChangeTracker> ApplyEvitiChanges(this DbContext context, IClientChangeTracker item)
        {
            List<IClientChangeTracker> AttachedItems = new List<IClientChangeTracker>();             

            context.ChangeTracker.TrackGraph(item, node =>
            {
                var subItem = node.Entry.Entity;

                if (!(node.Entry.Entity is IClientChangeTracker trackable))
                {

                    return;
                }

                EntityState newState = EntityState.Unchanged;

                var IsKeySet = node.Entry.IsKeySet;

                // this is the default state that typically does not need to be set.

                if (trackable.TrackingState == TrackingState.Unchanged)
                {
                    if (IsKeySet == false)
                    {
                        newState = EntityState.Added;
                    }
                    else
                    {
                        newState = EntityState.Unchanged;
                    }
                    SetEntityState(node.Entry, newState, trackable);

                }
                else
                {
                    // This is a forced state (added, modified, or deleted)
                    // it is only needed in these cases. 
                    // 1. In a deleted scenarios where an item in a collection should be marked as deleted.  
                    // 2. only set if in a many to many setup where there are two foreign key set a a primary key.   In this case new record that set the keys (not the objects) then an the trackable type should be added
                    // 3. if you want to force a full update of all properties. 
                    node.Entry.State = trackable.TrackingState.ToEntityState();
                }

            });

            return AttachedItems;
        }

        private static void SetEntityState(EntityEntry entry, EntityState state, IClientChangeTracker trackable)
        {
            // Set entity state to tracking state
            entry.State = state;

            //if (state==EntityState.Unchanged)
            // {

            //     string t = string.Empty;
            // }

            // Set modified properties
            if ((entry.State == EntityState.Unchanged || entry.State == EntityState.Modified) && trackable.ModifiedProperties != null)
            {
                foreach (var property in trackable.ModifiedProperties)
                {
                    entry.Property(property).IsModified = true;
                }

            }
        }




        /// <summary>
        /// This will reset all the eviti tracked objects modified state
        /// </summary>
        /// <param name="context"></param>
        public static void AcceptChanges(this DbContext context)
        {
            var allEntities = context.ChangeTracker.Entries<IClientChangeTracker>()
            //.Where(p => p.State == EntityState.Added)
            .Select(p => p.Entity).ToList();

            foreach (var item in allEntities)
            {
                ResetTracking(item);
            }

        }
        /// <summary>
        ///  this will accept a list of tracked entities to reset their tracked state. It's used in the reset process right now.
        /// </summary>
        /// <param name="Entries"></param>
        public static void ResetTrackingOnEntityEntry(List<EntityEntry> Entries)
        {

          foreach(var item in Entries)
            {
                IClientChangeTracker trackable = item.Entity as IClientChangeTracker;
                
                if (trackable != null)
                {
                    ResetTracking(trackable);
                }

            }
        }

        /// <summary>
        /// This will reset the Modified Properties on the eviti tracked objects
        /// </summary>
        /// <param name="trackable"></param>
        private static void ResetTracking(IClientChangeTracker trackable)
        {
            //if (trackable.TrackingState != TrackingState.Unchanged)
            //    trackable.TrackingState = TrackingState.Unchanged;
            if (trackable.ModifiedProperties?.Count > 0)
            {
                trackable.ModifiedProperties.Clear();
            }


        }

        /// <summary>
        ///  This is used to Detach all items for the change tracker.  
        ///  
        /// It is needed for cases were you want to update the same object in different times using the same DB contact.
        /// </summary>
        /// <param name="context"></param>
        public static void DetachAllEntities(this DbContext context)
        {
            //var changedEntriesCopy = this.ChangeTracker.Entries()
            //    .Where(e => e.State == EntityState.Added ||
            //                e.State == EntityState.Modified ||
            //                e.State == EntityState.Deleted)
            //    .ToList();

            IEnumerable<EntityEntry> trackedEntities = context.ChangeTracker.Entries() 
           //.Where(e => e.State == EntityState.Added ||
           //            e.State == EntityState.Modified ||
           //            e.State == EntityState.Deleted)
           .ToList();
           // DetachAllEntities(trackedEntities);
            foreach (var entry in trackedEntities)
            {
                entry.State = EntityState.Detached;
            }


            var test2 = context.ChangeTracker.Entries().ToList();

            if (test2.Count>0)
            {
                throw new System.ApplicationException("Tracked Item Count should be zero");
            }

        }

        public static void DetachAllEntities(this DbContext context, IEnumerable<EntityEntry> trackedEntities)
        {
         
            foreach (var item in trackedEntities)
            {
          
                context.Entry(item.Entity).State = EntityState.Detached;
              
            }

        }

        public static IEnumerable<EntityEntry> GetTrackedItems(this DbContext context)
        {
            var all = context.ChangeTracker.Entries().ToList();
            if (all.Count > 0)
            {
                string t = string.Empty;
            }
            return all;
        }


        public static void DeleteGraph(this DbContext context, IEnumerable<IClientChangeTracker> items)
        {
            // Apply changes to collection of items
            foreach (var item in items)
            {
                context.DeleteGraph(item);
            }

        }

        public static void DeleteGraph(this DbContext context, IClientChangeTracker item)
        {

            context.ChangeTracker.TrackGraph(item, node =>
            {
                string a = string.Empty;

                var subItem = node.Entry.Entity;

                var IsKeySet = node.Entry.IsKeySet;

                //if (IsKeySet == false)
                //{
                //    node.Entry.State = EntityState.Added;
                //}
                //else
                //{
                node.Entry.State = EntityState.Deleted;
                //}

                //// Exit if not ITrackable
                //if (!(node.Entry.Entity is ITrackable trackable))
                //{

                //    return;
                //}
            });
        }


        ///// <summary>
        ///// Set entity state to Detached for entities in an object graph.
        ///// </summary>
        ///// <param name="context">Used to query and save changes to a database</param>
        ///// <param name="item">Object that implements ITrackable</param>
        //public static void DetachEntities(this DbContext context, IClientChangeTracker item)
        //{
        //    // Detach each item in the object graph
        //    context.ChangeTracker.TrackGraph(item, node =>
        //    {
        //        node.Entry.State = EntityState.Detached;

        //    });
        //}
        /// < summary >
        /// Traverse an object graph to populate null reference properties.
        /// 
        /// This has not been tested yet
        /// </summary>
        /// <param name="context">Used to query and save changes to a database</param>
        /// <param name="item">Object that implements ITrackable</param>
        public static void LoadRelatedEntities(this DbContext context, IClientChangeTracker item)
        {
            // Traverse graph to load references          
            context.ChangeTracker.TrackGraph(item, n =>
                {

                    string t = string.Empty;
                    EntityState tt = n.Entry.State;
                    if (n.Entry.State == EntityState.Detached)
                    {

                        n.Entry.State = EntityState.Unchanged;

                        foreach (var reference in n.Entry.References)
                        {
                            if (!reference.IsLoaded)
                            {
                                reference.Load();

                            }

                        }

                    }

                });
        }



    }
}

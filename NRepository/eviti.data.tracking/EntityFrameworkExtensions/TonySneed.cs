//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace eviti.Data.Tracking.EntityFrameworkExtensions
//{
//    /// <summary>
//    /// Extension methods for DbContext to persist trackable entities.
//    /// </summary>
//    public static class DbContextExtensions
//    {
//        /// <summary>
//        /// Update entity state on DbContext for an object graph.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        public static void ApplyChanges(this DbContext context, ITrackable item)
//        {
//            // Detach root entity
//            context.Entry(item).State = EntityState.Detached;

//            // Recursively set entity state for DbContext entry
//            context.ChangeTracker.TrackGraph(item, node =>
//            {
//                // Exit if not ITrackable
//                if (!(node.Entry.Entity is ITrackable trackable)) return;

//                // Detach node entity
//                node.Entry.State = EntityState.Detached;

//                // Get related parent entity
//                if (node.SourceEntry != null)
//                {
//                    var relationship = node.InboundNavigation?.GetRelationshipType();
//                    switch (relationship)
//                    {
//                        case RelationshipType.OneToOne:
//                            // If parent is added set to added
//                            if (node.SourceEntry.State == EntityState.Added)
//                            {
//                                SetEntityState(node.Entry, TrackingState.Added.ToEntityState(), trackable);
//                            }
//                            else if (node.SourceEntry.State == EntityState.Deleted)
//                            {
//                                SetEntityState(node.Entry, TrackingState.Deleted.ToEntityState(), trackable);
//                            }
//                            else
//                            {
//                                SetEntityState(node.Entry, trackable.TrackingState.ToEntityState(), trackable);
//                            }
//                            return;
//                        case RelationshipType.ManyToOne:
//                            // If parent is added set to added
//                            if (node.SourceEntry.State == EntityState.Added)
//                            {
//                                SetEntityState(node.Entry, TrackingState.Added.ToEntityState(), trackable);
//                                return;
//                            }
//                            // If parent is deleted set to deleted
//                            var parent = node.SourceEntry.Entity as ITrackable;
//                            if (node.SourceEntry.State == EntityState.Deleted
//                                || parent?.TrackingState == TrackingState.Deleted)
//                            {
//                                try
//                                {
//                                    // Will throw if there are added children
//                                    SetEntityState(node.Entry, TrackingState.Deleted.ToEntityState(), trackable);
//                                }
//                                catch (InvalidOperationException e)
//                                {
//                                    throw new InvalidOperationException(Constants.ExceptionMessages.DeletedWithAddedChildren, e);
//                                }
//                                return;
//                            }
//                            break;
//                        case RelationshipType.OneToMany:
//                            // If trackable is set deleted set entity state to unchanged,
//                            // since it may be related to other entities.
//                            if (trackable.TrackingState == TrackingState.Deleted)
//                            {
//                                SetEntityState(node.Entry, TrackingState.Unchanged.ToEntityState(), trackable);
//                                return;
//                            }
//                            break;
//                    }
//                }

//                // Set entity state to tracking state
//                SetEntityState(node.Entry, trackable.TrackingState.ToEntityState(), trackable);
//            });
//        }

//        /// <summary>
//        /// Update entity state on DbContext for more than one object graph.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="items">Objects that implement ITrackable</param>
//        public static void ApplyChanges(this DbContext context, IEnumerable<ITrackable> items)
//        {
//            // Apply changes to collection of items
//            foreach (var item in items)
//                context.ApplyChanges(item);
//        }

//        /// <summary>
//        /// Set entity state to Detached for entities in more than one object graph.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="items">Objects that implement ITrackable</param>
//        public static void DetachEntities(this DbContext context, IEnumerable<ITrackable> items)
//        {
//            // Detach each item in the object graph
//            foreach (var item in items)
//                context.DetachEntities(item);
//        }

//        /// <summary>
//        /// Set entity state to Detached for entities in an object graph.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        public static void DetachEntities(this DbContext context, ITrackable item)
//        {
//            // Detach each item in the object graph
//            context.TraverseGraph(item, n => n.Entry.State = EntityState.Detached);
//        }

//        /// <summary>
//        /// Traverse an object graph to populate null reference properties.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        public static void LoadRelatedEntities(this DbContext context, ITrackable item)
//        {
//            // Traverse graph to load references          
//            context.TraverseGraph(item, n =>
//            {
//                if (n.Entry.State == EntityState.Detached)
//                    n.Entry.State = EntityState.Unchanged;
//                foreach (var reference in n.Entry.References)
//                {
//                    if (!reference.IsLoaded)
//                        reference.Load();
//                }
//            });
//        }

//        /// <summary>
//        /// Traverse more than one object graph to populate null reference properties.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="items">Objects that implement ITrackable</param>
//        public static void LoadRelatedEntities(this DbContext context, IEnumerable<ITrackable> items)
//        {
//            // Traverse graph to load references          
//            foreach (var item in items)
//                context.LoadRelatedEntities(item);
//        }

//        /// <summary>
//        /// Traverse an object graph asynchronously to populate null reference properties.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        public static async Task LoadRelatedEntitiesAsync(this DbContext context, ITrackable item)
//        {
//            // Detach each item in the object graph         
//            await context.TraverseGraphAsync(item, async n =>
//            {
//                if (n.Entry.State == EntityState.Detached)
//                    n.Entry.State = EntityState.Unchanged;
//                foreach (var reference in n.Entry.References)
//                {
//                    if (!reference.IsLoaded)
//                        await reference.LoadAsync();
//                }
//            });
//        }

//        /// <summary>
//        /// Traverse more than one object graph asynchronously to populate null reference properties.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="items">Objects that implement ITrackable</param>
//        public static async Task LoadRelatedEntitiesAsync(this DbContext context, IEnumerable<ITrackable> items)
//        {
//            // Traverse graph to load references
//            foreach (var item in items)
//                await context.LoadRelatedEntitiesAsync(item);
//        }

//        /// <summary>
//        /// Traverse an object graph to set TrackingState to Unchanged.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        public static void AcceptChanges(this DbContext context, ITrackable item)
//        {
//            // Traverse graph to set TrackingState to Unchanged
//            context.TraverseGraph(item, n =>
//            {
//                if (n.Entry.Entity is ITrackable trackable)
//                {
//                    if (trackable.TrackingState != TrackingState.Unchanged)
//                        trackable.TrackingState = TrackingState.Unchanged;
//                    if (trackable.ModifiedProperties?.Count > 0)
//                        trackable.ModifiedProperties.Clear();
//                }
//            });
//        }

//        /// <summary>
//        /// Traverse more than one object graph to set TrackingState to Unchanged.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="items">Objects that implement ITrackable</param>
//        public static void AcceptChanges(this DbContext context, IEnumerable<ITrackable> items)
//        {
//            // Traverse graph to set TrackingState to Unchanged
//            foreach (var item in items)
//                context.AcceptChanges(item);
//        }

//        private static void SetEntityState(EntityEntry entry, EntityState state, ITrackable trackable)
//        {
//            // Set entity state to tracking state
//            entry.State = state;

//            // Set modified properties
//            if (entry.State == EntityState.Modified
//                && trackable.ModifiedProperties != null)
//            {
//                foreach (var property in trackable.ModifiedProperties)
//                    entry.Property(property).IsModified = true;
//            }
//        }
//    }


//    /// <summary>
//    /// Internal extension methods for trackable entities.
//    /// Depends on Entity Framework Core infrastructure, which may change in future releases.
//    /// </summary>
//    public static class DbContextExtensionsInternal
//    {
//        /// <summary>
//        /// Traverse an object graph executing a callback on each node.
//        /// Depends on Entity Framework Core infrastructure, which may change in future releases.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        /// <param name="callback">Callback executed on each node in the object graph</param>
//        public static void TraverseGraph(this DbContext context, object item,
//            Action<EntityEntryGraphNode> callback)
//        {
//            IStateManager stateManager = context.Entry(item).GetInfrastructure().StateManager;
//            var node = new EntityEntryGraphNode(stateManager.GetOrCreateEntry(item), null, null);
//            IEntityEntryGraphIterator graphIterator = new EntityEntryGraphIterator();
//            var visited = new HashSet<int>();

//            graphIterator.TraverseGraph(node, n =>
//            {
//                // Check visited
//                if (visited.Contains(n.Entry.Entity.GetHashCode()))
//                    return false;

//                // Execute callback
//                callback(n);

//                // Add visited
//                visited.Add(n.Entry.Entity.GetHashCode());

//                // Return true if node state is null
//                return true;
//            });
//        }

//        /// <summary>
//        /// Traverse an object graph asynchronously executing a callback on each node.
//        /// Depends on Entity Framework Core infrastructure, which may change in future releases.
//        /// </summary>
//        /// <param name="context">Used to query and save changes to a database</param>
//        /// <param name="item">Object that implements ITrackable</param>
//        /// <param name="callback">Async callback executed on each node in the object graph</param>
//        public static async Task TraverseGraphAsync(this DbContext context, object item,
//            Func<EntityEntryGraphNode, Task> callback)
//        {
//            IStateManager stateManager = context.Entry(item).GetInfrastructure().StateManager;
//            var node = new EntityEntryGraphNode(stateManager.GetOrCreateEntry(item), null, null);
//            IEntityEntryGraphIterator graphIterator = new EntityEntryGraphIterator();
//            var visited = new HashSet<int>();

//            await graphIterator.TraverseGraphAsync(node, async (n, ct) =>
//            {
//                // Check visited
//                if (visited.Contains(n.Entry.Entity.GetHashCode()))
//                    return false;

//                // Execute callback
//                await callback(n);

//                // Add visited
//                visited.Add(n.Entry.Entity.GetHashCode());

//                // Return true if node state is null
//                return true;
//            });
//        }
//    }


//    /// <summary>
//    /// Extension methods for INavigation.
//    /// </summary>
//    public static class NavigationExtensions
//    {
//        /// <summary>
//        /// Infer relationship type from an INavigation.
//        /// </summary>
//        /// <param name="nav">Navigation property which can be used to navigate a relationship.</param>
//        /// <returns>Type of relationship between entities; null if INavigation is null.</returns>
//        public static RelationshipType? GetRelationshipType(this INavigation nav)
//        {
//            if (nav == null) return null;
//            if (nav.ForeignKey.IsUnique)
//                return RelationshipType.OneToOne;
//            return nav.IsDependentToPrincipal() ? RelationshipType.OneToMany : RelationshipType.ManyToOne;
//        }
//    }


//    /// <summary>
//    /// Type of relationship between entities.
//    /// </summary>
//    public enum RelationshipType
//    {
//        /// <summary>Many to one relationship.</summary>
//        ManyToOne,
//        /// <summary>One to one relationship.</summary>
//        OneToOne,
//        /// <summary>Many to many relationship.</summary>
//        ManyToMany,
//        /// <summary>One to many relationship.</summary>
//        OneToMany
//    }


//    /// <summary>
//    /// Extension methods for classes implementing ITrackable.
//    /// </summary>
//    public static class TrackableExtensions
//    {
//        /// <summary>
//        /// Convert TrackingState to EntityState.
//        /// </summary>
//        /// <param name="state">Trackable entity state</param>
//        /// <returns>EF entity state</returns>
//        public static EntityState ToEntityState(this TrackingState state)
//        {
//            switch (state)
//            {
//                case TrackingState.Added:
//                    return EntityState.Added;
//                case TrackingState.Modified:
//                    return EntityState.Modified;
//                case TrackingState.Deleted:
//                    return EntityState.Deleted;
//                default:
//                    return EntityState.Unchanged;
//            }
//        }

//        /// <summary>
//        /// Convert EntityState to TrackingState.
//        /// </summary>
//        /// <param name="state">EF entity state</param>
//        /// <returns>Trackable entity state</returns>
//        public static TrackingState ToTrackingState(this EntityState state)
//        {
//            switch (state)
//            {
//                case EntityState.Added:
//                    return TrackingState.Added;
//                case EntityState.Modified:
//                    return TrackingState.Modified;
//                case EntityState.Deleted:
//                    return TrackingState.Deleted;
//                default:
//                    return TrackingState.Unchanged;
//            }
//        }
//    }


//    /// <summary>
//    /// File containing constants.
//    /// </summary>
//    public static class Constants
//    {
//        /// <summary>
//        /// Exception messages.
//        /// </summary>
//        public static class ExceptionMessages
//        {
//            /// <summary>
//            /// Exception message for deleted with children.
//            /// </summary>
//            public const string DeletedWithAddedChildren =
//                "An entity may not be marked as Deleted if it has related entities which are marked as Added. " +
//                "Remove added related entities before deleting a parent entity.";

//            /// <summary>
//            /// Exception message for relationship not determined.
//            /// </summary>
//            public const string RelationshipNotDetermined =
//                "Cannot determine relationship type for {0} property on {1}.";
//        }
//    }



//    /// <summary>
//    /// Change-tracking state of an entity.
//    /// </summary>
//    public enum TrackingState
//    {
//        /// <summary>Existing entity that has not been modified.</summary>
//        Unchanged,
//        /// <summary>Newly created entity.</summary>
//        Added,
//        /// <summary>Existing entity that has been modified.</summary>
//        Modified,
//        /// <summary>Existing entity that has been marked as deleted.</summary>
//        Deleted
//    }

//    /// <summary>
//    /// Interface implemented by entities that are change-tracked.
//    /// </summary>
//    public interface ITrackable
//    {
//        /// <summary>
//        /// Change-tracking state of an entity.
//        /// </summary>
//        TrackingState TrackingState { get; set; }

//        /// <summary>
//        /// Properties on an entity that have been modified.
//        /// </summary>
//        ICollection<string> ModifiedProperties { get; set; }
//    }

//    /// <summary>
//    /// Provides an EntityIdentifier for correlation when merging changes.
//    /// </summary>
//    public interface IMergeable
//    {
//        /// <summary>Identifier used for correlation with MergeChanges.</summary>
//        Guid EntityIdentifier { get; set; }
//    }

//}

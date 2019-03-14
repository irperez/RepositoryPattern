//using eviti.data.tracking.EntityFrameworkExtensions;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace eviti.data.tracking.DomainEvent
//{
//    public interface IDomainEvent { }


//    public static class DomainEvents
//    {
//        private static readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

//        public static void Register<T>(Action<T> eventHandler)
//            where T : IDomainEvent
//        {

//            string t = string.Empty;
//            _handlers[typeof(T)].Add(eventHandler);
//        }

//        public static void Raise<T>(T domainEvent)
//            where T : IDomainEvent
//        {
//            foreach (Delegate handler in _handlers[domainEvent.GetType()])
//            {
//                var action = (Action<T>)handler;
//                action(domainEvent);
//            }
//        }
//    }
//    public class AuditGenerated : IDomainEvent
//    {
//        public AuditGenerated(List<ChangeLog> auditItems)
//        {
//            AuditItems = auditItems;
//        }
//        public List<ChangeLog> AuditItems { get; }
//    }


//    //public class OrderSubmitted : IDomainEvent
//    //{
//    //    public Contact Order { get; }
//    //}



//    //public static class OrderNotification
//    //{
//    //    static OrderNotification()
//    //    {
//    //        DomainEvents.Register<OrderSubmitted>(ev => ProcessSubmittedOrder(ev));
//    //    }

//    //    private static void ProcessSubmittedOrder(OrderSubmitted ev)
//    //    {
//    //        /* Use ev.Order.Lines to compose an email and send it to ev.Order.Customer */
//    //    }
//    //}
//}

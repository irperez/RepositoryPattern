using eviti.data.tracking.DomainEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvitiContact.Service.Events
{


    public class Ping : INotification { }


    public class Pong1 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 1");
            return Task.CompletedTask;
        }
    }
    public class Pong2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 2");
            return Task.CompletedTask;
        }
    }


    public class AuditEventsV2Haldler : INotificationHandler<AuditEventsV2Generated>
    {
        public Task Handle(AuditEventsV2Generated notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Pong 3");
            return Task.CompletedTask;
        }
    }
}

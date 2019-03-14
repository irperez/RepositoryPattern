using eviti.data.tracking.EntityFrameworkExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.DomainEvent
{
    public class AuditEventsV2Generated : INotification
    {
        public AuditEventsV2Generated(List<ChangeLog> auditItems)
        {
            AuditItems = auditItems;
        }
        public List<ChangeLog> AuditItems { get; }
    }

}

using MediatR;
using System;
using System.Collections.Generic;

namespace eviti.data.tracking.EntityFrameworkExtensions
{ 
  


    public class ChangeLog
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanged { get; set; }

        public string EntityState { get; set; }
    }
}

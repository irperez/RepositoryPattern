using System;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.Interfaces
{ 
    public interface IAuditedEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        string Version { get; set; }
    }

}

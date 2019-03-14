using eviti.Data.Tracking.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace eviti.data.tracking.Interfaces
{
    public interface IClientChangeTracker
    {
        Guid EntityIdentifier { get; set; }
        bool IsDirty { get; set; }
        ICollection<string> ModifiedProperties { get; set; }
        TrackingState TrackingState { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
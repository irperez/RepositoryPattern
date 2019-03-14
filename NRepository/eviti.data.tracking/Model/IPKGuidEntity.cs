using System;

namespace eviti.Data.Tracking.Model
{
    public interface IPKGuidEntity : IEntity, IEquatable<Guid>
    {
        Guid Guid { get; set; }
    }
}

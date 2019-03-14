using System;

namespace eviti.Data.Tracking.Model
{
    public interface IPKLongEntity : IEntity, IEquatable<long>
    {
        long Id { get; set; }
    }
}

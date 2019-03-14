using System;

namespace eviti.Data.Tracking.Model
{
    public interface IPKStringEntity : IEntity, IEquatable<string>
    {
        string Id { get; set; }
    }
}

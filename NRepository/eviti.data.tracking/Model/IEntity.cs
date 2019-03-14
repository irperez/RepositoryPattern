namespace eviti.Data.Tracking.Model
{
    public interface IEntity
    {
        bool IsReadOnly { get; set; } //defaults to false

        void Initialize();
    }
}

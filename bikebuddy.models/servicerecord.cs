namespace bikebuddy.models
{
    public class ServiceRecord
    {
        public ServiceRecord(string name, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Component? Component { get; set; }
        public Bike? Bike { get; set; }
        public DateTime? ServiceDate { get; set; }
        public long? Odometer { get; set; }
        public string? ServiceBy { get; set; }
        public string? ServiceLocation { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceDetails { get; set; }
    }
}
namespace bikebuddy.models
{
    public class ServiceSchedule
    {
        public ServiceSchedule(string name, string? description = null)
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
        public TimeSpan? TimeInterval { get; set; }
        public long? OdometerInterval { get; set; }

    }
}
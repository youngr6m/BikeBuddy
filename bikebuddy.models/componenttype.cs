namespace bikebuddy.models
{
    public class ComponentType
    {
        public ComponentType(string name, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public Uri? ImageURL { get; set; }
        public ServiceSchedule? DefaultServiceSchedule { get; set; }
    }
}
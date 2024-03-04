namespace bikebuddy.models
{
    public class Component
    {
        public Component(string name, string? description = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description ?? string.Empty;
        }

        public Guid Id { get; }
        public string ComponentType { get; set; }
        public string Model { get; set; }
        // max length 50 chars
        public string Name { get; set; }
        // max length 100 chars
        public string Description { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public long Odometer { get; set; }
        public Uri? WebReference { get; set; }
    }
}

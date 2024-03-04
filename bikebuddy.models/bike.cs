namespace bikebuddy.models
{
    public class Bike
    {
        public Bike(string make, string? model = null, string? nickname = null)
        {
            Id = Guid.NewGuid();
            Make = make;
            Model = model ?? string.Empty;
            NickName = nickname ?? string.Empty;
        }
        public Guid Id { get;}
        // max length 50 chars
        public string Make { get; set; }
        // max length 50 chars
        public string Model { get; set; }
        // max length 100 chars
        public string NickName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long Odometer { get; set; }
        public string Colour { get; set; }
       
    }
}

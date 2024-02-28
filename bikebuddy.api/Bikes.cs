using bikebuddy.models;

namespace bikebuddy.api
{

    public class BikeManager
    {
        static Bike[] _bikes =
        [
            new Bike("Focus", "Cayo Evo 1.0", "Road"),
            new Bike("Focus", "Mares CX", "Gravel"),
            new Bike("Trek", "Cobia 13", "MTB"),
            new Bike("Trek", "Domane+", "e-Road"),
            new Bike("Trek", "Powerfly 4", "e-MTB"),
            new Bike("Canondale", "Synapse", "Bea Road"),
        ];    

        public async Task<Bike[]> GetBikesAsync()
        {
            return _bikes;
        }

        public async Task<Bike> AddBikeAsync(Bike bike)
        {
            _bikes.Append(bike);
            return bike;
        }

        public async Task<Bike> UpdateBikeAsync(Bike bike)
        {
            var index = Array.FindIndex(_bikes, b => b.Id == bike.Id);
            if (index < 0)
            {
                throw new InvalidOperationException("Bike not found");
            }
            _bikes[index] = bike;
            return bike;
        }

        public async Task<Bike> DeleteBikeAsync(Guid id)
        {
            var index = Array.FindIndex(_bikes, b => b.Id == id);
            if (index < 0)
            {
                throw new InvalidOperationException("Bike not found");
            }
            var bike = _bikes[index];
            _bikes = _bikes.Where(b => b.Id != id).ToArray();
            return bike;
        }


    }
}

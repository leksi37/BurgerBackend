namespace WebApi.Models.BurgerPlaces
{
    public class BurgerPlaceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double OverallScore { get; set; }
    }
}

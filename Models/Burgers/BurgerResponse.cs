namespace WebApi.Models.Burgers
{
    public class BurgerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int ScoreId { get; set; }
        public int BurgerPlaceId { get; set; }

    }
}

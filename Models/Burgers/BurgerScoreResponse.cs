namespace WebApi.Models.Burgers
{
    public class BurgerScoreResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double VisualScore { get; set; }
        public double TasteScore { get; set; }
        public double TextureScore { get; set; }
        public double OverallScore { get; set; }
        public int BurgerPlaceId { get; set; }

    }
}

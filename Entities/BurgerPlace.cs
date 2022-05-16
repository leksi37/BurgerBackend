using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    /**
     * Burger place entity model
     * (Code first approach)
     */
    public class BurgerPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double OverallScore { get; set; }
    }
}

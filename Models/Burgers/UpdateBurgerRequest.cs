using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Burgers
{
    public class UpdateBurgerRequest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int BurgerPlaceId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Burgers
{
    public class AddBurgerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int BurgerPlaceId { get; set; }
    }
}

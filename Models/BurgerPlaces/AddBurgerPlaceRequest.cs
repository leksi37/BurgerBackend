using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.BurgerPlaces
{
    public class AddBurgerPlaceRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

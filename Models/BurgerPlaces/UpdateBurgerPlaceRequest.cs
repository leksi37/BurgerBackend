using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.BurgerPlaces
{
    public class UpdateBurgerPlaceRequest
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
    }
}

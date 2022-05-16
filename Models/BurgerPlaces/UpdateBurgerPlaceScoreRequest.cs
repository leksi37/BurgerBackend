using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.BurgerPlaces
{
    public class UpdateBurgerPlaceScoreRequest
    { 

        [Required]
        public int Id { get; set; }
        [Required]
        public double OverallScore { get; set; }

    }
}

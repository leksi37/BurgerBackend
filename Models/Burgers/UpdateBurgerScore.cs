using System.ComponentModel.DataAnnotations;
namespace WebApi.Models.Burgers;
    public class UpdateBurgerScoreRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double VisualScore { get; set; }
        [Required]
        public double TasteScore { get; set; }
        [Required]
        public double TextureScore { get; set; }

    }

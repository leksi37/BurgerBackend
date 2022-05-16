using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Burgers
{
    //to finish
    public class ReviewBurgerRequest
    {
        [Required]
        public int BurgerId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

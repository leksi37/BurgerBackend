using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    /**
     * Burger entity model
     * (Code first approach)
     */
    public class Burger
    {
        public int Id { get; set; }
        [ForeignKey("Score")]
        public int ScoreId { get; set; }
        [ForeignKey("BurgerPlace")]
        public int BurgerPlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
    }
}

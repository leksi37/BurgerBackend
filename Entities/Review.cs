using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    /**
     * Review entity model
     * (Code first approach)
     */
    public class Review
    {
        public int Id { get; set; }
        [ForeignKey("Burger")]
        public int BurgerId { get; set; }
        public string Text { get; set; }
        [ForeignKey("Score")]
        public int ScoreId { get; set; }
       // public string? Image { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    /**
     * Score entity model
     * (Code first approach)
     * Created to avoid DRY, since the fields are needed both in Burger and in Review
     */

    public class Score
    {
        public int Id { get; set; }
        public double VisualScore { get; set; }
        public double TasteScore { get; set; }
        public double TextureScore { get; set; }
        public double OverallScore { get; set; }
    }
}

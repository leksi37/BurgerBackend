using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Location
{
    public class LocationRequest
    {
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        public int Radius { get; set; }
        public string keyword { get; set; }
    }
}

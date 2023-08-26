using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Around_VietNam_Web.Models
{
    public class TouristAreas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Avatar { get; set; }
        [ForeignKey("Areas")]
        public int AreaId { get; set; }
        [Required]
        public List<ImageDetails> ImageDetails { get; set; }
        public float AvgRating { get; set; }
        public Areas Areas { get; set; }

    }
}

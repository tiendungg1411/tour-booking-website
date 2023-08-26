using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Around_VietNam_Web.Models
{
    public class ImageDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [ForeignKey("TouristAreas")]
        public int TouristAreaId { get; set; }
        public TouristAreas TouristAreas { get; set; }

    }
}

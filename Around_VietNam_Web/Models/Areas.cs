using System.ComponentModel.DataAnnotations;

namespace Around_VietNam_Web.Models
{
    public class Areas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<TouristAreas> TouristAreas { get; set;}
    }
}

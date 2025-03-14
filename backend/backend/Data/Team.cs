using System.ComponentModel.DataAnnotations;

namespace backend.Data
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public int CaptainID { get; set; }
    }
}

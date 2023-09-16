using System.ComponentModel.DataAnnotations;

namespace TelerikManager.Models
{
    public class Manager
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string EnteredBy { get; set; }
        [Required]
        public DateTime EnteredDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set;}
    }
}

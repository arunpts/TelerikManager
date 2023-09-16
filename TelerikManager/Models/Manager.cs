using System.ComponentModel.DataAnnotations;

namespace TelerikManager.Models
{
    public class Manager
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(10, ErrorMessage = "Phone number must be exactly 10 digits.", MinimumLength = 10)]
        public string Phone  { get; set; }

        [Required(ErrorMessage = "Place is required")]
        public string Place{ get; set; }
        public string EnteredBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnteredDate { get; set; }
        public string UpdatedBy{ get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }



    }
}

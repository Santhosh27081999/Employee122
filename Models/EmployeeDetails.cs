using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical1App.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        public string? Mobile { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? Password { get; set; }


        public DateTime?  DOB { get; set; }
    }

    public enum Gender
    {
     Male,
     Female
    }

    public class EmployeeExperienceDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeDetails")]
        public int EmployeeID { get; set; }

        [Required]
        public string? CompanyName { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }


        [Required]
        public DateTime? EndDate { get; set; }

        [Required]
        public decimal? CTC { get; set; }

        public string? IsCurrentlyWorking { get; set; }

        public string? ReasonForleaving { get; set; }


    }
}

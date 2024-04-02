using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practical2app.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)] // Adjust maximum length as needed
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(10)] // Adjust maximum length as needed
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Mobile must be numeric")]
        public string Mobile { get; set; }

        [Required]
        [MaxLength(100)] // Adjust maximum length as needed
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and be at least 8 characters long")]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class EmployeeExperienceDetails
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("EmployeeDetails")]
        public int FKEmployeeId { get; set; }

        [Required]
        [MaxLength(100)] // Adjust maximum length as needed
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTC { get; set; }

        [Required]
        public bool IsCurrentlyWorking { get; set; }

        [MaxLength(500)] // Adjust maximum length as needed
        public string ReasonForLeaving { get; set; }

        // Navigation property for Employee
        public EmployeeDetails Employee { get; set; }
    }
}


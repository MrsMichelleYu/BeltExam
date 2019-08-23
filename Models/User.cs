using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [Column("FirstName", TypeName = "VARCHAR(45)")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [Column("LastName", TypeName = "VARCHAR(45)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email", TypeName = "VARCHAR(45)")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and 1 special character.")]
        [DataType(DataType.Password)]
        [Column("Password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Act> CreatedActivities { get; set; }
        public List<JoinedActivity> JoinedActivities { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string LogEmail { get; set; }
        [Required]
        public string LogPassword { get; set; }
    }
}
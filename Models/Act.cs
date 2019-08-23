using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class Act
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        public string Title { get; set; }

        [FutureDate]
        public DateTime? Date { get; set; }

        public string Time { get; set; }

        public int Duration { get; set; }

        public string Hours { get; set; }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }

        public User Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<JoinedActivity> Participants { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class JoinedActivity
    {
        [Key]
        public int JoinedActivityId { get; set; }

        public int UserId { get; set; }

        public int ActivityId { get; set; }

        public User ParticipantInfo { get; set; }

        public Act ActivityInfo { get; set; }

    }

}
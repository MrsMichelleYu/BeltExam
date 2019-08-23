using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        // base() calls the parent class' constructor passing the "options" parameter along

        public DbSet<User> Users { get; set; }

        public DbSet<Act> Acts { get; set; }

        public DbSet<JoinedActivity> JoinedActivities { get; set; }
    }
}
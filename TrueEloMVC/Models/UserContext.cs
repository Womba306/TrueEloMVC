using Microsoft.EntityFrameworkCore;


namespace TrueEloMVC.Models
{
    public class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        //public DbSet<Summoner> Summoners { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) 
        { 
        Database.EnsureCreated();
        }
    }
}

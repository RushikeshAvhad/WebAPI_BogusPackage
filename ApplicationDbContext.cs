using Microsoft.EntityFrameworkCore;
using WebAPI_BogusPackage.Model;

namespace WebAPI_BogusPackage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}

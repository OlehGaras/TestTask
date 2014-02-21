using System.Data.Entity;
using Message;

namespace Server
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}

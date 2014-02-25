using System.Data.Entity;
using Message;

namespace Service
{
    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using TMS.Models;

namespace TMS.Context
{
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}

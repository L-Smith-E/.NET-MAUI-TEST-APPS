using MAUI_Test_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUI_Test_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}

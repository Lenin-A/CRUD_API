using EzovionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EzovionAPI.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> option)
        : base(option)
        { }

        public DbSet<Student> Students { get; set; }

    }
}
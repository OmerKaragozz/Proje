using Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-10MJDPA; TrustServerCertificate=True; Database=ProjeDb;uid=sa;pwd=123;");
        }
        public DbSet<Bilgi> Bilgiler { get; set; }
    }

}
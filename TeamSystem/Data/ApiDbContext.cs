using Microsoft.EntityFrameworkCore;
using TeamSystem.Models;

namespace TeamSystem.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<KategoriPostim> KategoriPostim { get; set; }

        public DbSet<User> User { get; set; }

    }

}

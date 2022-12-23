using Microsoft.EntityFrameworkCore;

namespace OyunSitesi.VeriTabani
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}

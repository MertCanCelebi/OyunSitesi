using Microsoft.EntityFrameworkCore;

namespace OyunSitesi.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Oyun> Oyunlar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
    }
}

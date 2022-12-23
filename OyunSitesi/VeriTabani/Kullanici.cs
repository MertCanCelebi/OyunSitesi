using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.VeriTabani
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? AdSoyad { get; set; } = null;

        [Required]
        [StringLength(30)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(20)]
        public string Sifre { get; set; }

        [Required]
        [StringLength(20)]
        public string Rol { get; set; } = "kullanici";
    }
}

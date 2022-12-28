using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.VeriTabani
{
    [Table("Oyunlar")]
    public class Oyun
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? OyunAd { get; set; } = null;

        [StringLength(100000)]
        public string Icerik { get; set; }

        [StringLength(200)]
        public string Yorum { get; set; }

        [Required]
        [StringLength(20)]
        public int KategoriId { get; set; }

        public string Resim { get; set; }
    }
}

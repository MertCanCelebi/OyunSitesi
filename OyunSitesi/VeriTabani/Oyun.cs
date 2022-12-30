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

       
        public int Yorum { get; set; }

        [Required]
        public int KategoriId { get; set; }

        public string Resim { get; set; }
    }
}

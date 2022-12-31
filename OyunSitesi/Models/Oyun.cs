using OyunSitesi.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.Models
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

        virtual public Kategori Kategori { get; set; }

        public string Resim { get; set; }

        virtual public ICollection<Yorum> Yorumlar { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.Models
{
    [Table("Yorumlar")]
    public class Yorum
    {
        [Key]
        public int Id { get; set; }

        public int KullaniciId { get; set; }

        virtual public Kullanici Kullanici { get; set; }
        public int OyunId { get; set; }

        virtual public Oyun Oyun { get; set; }

        [StringLength(100000)]
        public string YorumIcerik { get; set; }
    }
}

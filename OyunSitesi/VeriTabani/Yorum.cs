using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.VeriTabani
{
    [Table("Yorumlar")]
    public class Yorum
    {
        [Key]
        public int Id { get; set; }

        public int KullaniciId { get; set; }
        public int OyunId { get; set; }

        [StringLength(100000)]
        public string YorumIcerik { get; set; }
    }
}

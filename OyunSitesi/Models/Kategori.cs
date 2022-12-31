using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunSitesi.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Ad { get; set; } = null;

        virtual public ICollection<Oyun> Oyunlar { get; set; }


    }
}

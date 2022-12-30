using System.ComponentModel.DataAnnotations;

namespace OyunSitesi.Models
{
    //public class KategoriModel
    //{
    //    public int Id { get; set; }
    //    public string? Ad { get; set; } = null;
       
    //}
    public class OyunModel
    {
       
        public int Id { get; set; }

 
        public string? OyunAd { get; set; } = null;

   
        public string Icerik { get; set; }

        public int Yorum { get; set; }

        public int KategoriId { get; set; }

        public string Resim { get; set; }
    }
    public class OyunEkleModel
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
    public class OyunDuzenleModel
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


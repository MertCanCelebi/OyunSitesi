using System.ComponentModel.DataAnnotations;

namespace OyunSitesi.Models
{
    public class KategoriModel
    {
        public int Id { get; set; }
        public string? Ad { get; set; } = null;
       
    }
    public class OyunModel
    {
       
        public int Id { get; set; }

 
        public string? OyunAd { get; set; } = null;

   
        public string Icerik { get; set; }

        public string Yorum { get; set; }

        public int KategoriId { get; set; }

        public string Resim { get; set; }
    }

}


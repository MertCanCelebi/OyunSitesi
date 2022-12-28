using System.ComponentModel.DataAnnotations;

namespace OyunSitesi.Models
{
    public class KullaniciModel
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; } = null;
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; } = "kullanici";
    }
    public class KullaniciEkleModel
    {
        public string? AdSoyad { get; set; } = null;

        [Required(ErrorMessage = "Kullanici Adinizi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Kullanici Adi Maksimum 30 Karakterli Olmalı.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Sifreyi Giriniz.")]
        [MaxLength(20, ErrorMessage = "Sifre Maksimum 20 Karakterli Olmali.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Sifreyi Tekrar Giriniz.")]
        [MaxLength(20, ErrorMessage = "Sifre Maksimum 20 Karakterli Olmali.")]
        [Compare(nameof(Sifre))]
        public string TekrarSifre { get; set; }
        public string Rol { get; set; } = "kullanici";
    }
    public class KullaniciDuzenleModel
    {
        public string? AdSoyad { get; set; } = null;

        [Required(ErrorMessage = "Kullanici Adinizi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Kullanici Adi Maksimum 30 Karakterli Olmalı.")]
        public string KullaniciAdi { get; set; }

     
        public string Rol { get; set; } = "kullanici";
    }
}

using System.ComponentModel.DataAnnotations;

namespace OyunSitesi.Models
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "Kullanici Adinizi Giriniz.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, ErrorMessage = "Kullanici Adi Maksimum 50 Karakterli Olmalı.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Sifreyi Giriniz.")]
        [MaxLength(20, ErrorMessage = "Sifre Maksimum 20 Karakterli Olmali.")]
        public string Sifre { get; set; }
    }
}

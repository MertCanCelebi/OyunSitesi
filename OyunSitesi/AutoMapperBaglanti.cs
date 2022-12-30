using AutoMapper;
using OyunSitesi.Models;
using OyunSitesi.VeriTabani;
namespace OyunSitesi
{
    public class AutoMapperBaglanti:Profile
    {
        public AutoMapperBaglanti()
        {
            
            CreateMap<Kullanici, KullaniciModel>().ReverseMap();
            CreateMap<Kullanici, KullaniciEkleModel>().ReverseMap();
            CreateMap<Kullanici, KullaniciDuzenleModel>().ReverseMap();
           // CreateMap<Kategori, KategoriModel>().ReverseMap();
            CreateMap<Oyun,OyunModel>().ReverseMap();      
            CreateMap<Oyun, OyunEkleModel>().ReverseMap();
            CreateMap<Oyun, OyunDuzenleModel>().ReverseMap();
            CreateMap<Yorum, YorumModel>().ReverseMap();
         

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OyunSitesi.Models
{
    public class YorumModel
    {
        [Key]
        public int Id { get; set; }


        public int OyunId { get; set; }

        public string YorumIcerik { get; set; }
    }
   
}

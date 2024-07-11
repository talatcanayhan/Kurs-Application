using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KursUygulamasi.Data;

namespace KursUygulamasi.Models
{
    public class KursViewModel
    {
        public int KursId { get; set; }

        [Display(Name = "Kurs Başlığı")]
        public string? Baslik { get; set;}

        public string? KursAciklama { get; set; }

        public int OgretmenId { get; set; }
        
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}

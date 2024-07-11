using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursUygulamasi.Data
{
    public class Kurs
    {
        public int KursId { get; set; }

        [Display(Name = "Kurs Başlığı")]
        [Required]
        [StringLength(50)]
        public string? Baslik { get; set;}

        public string? KursAciklama { get; set; }

        public int OgretmenId { get; set; }

        public Ogretmen Ogretmen { get; set; } = null!;

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}

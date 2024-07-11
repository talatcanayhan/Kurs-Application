using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursUygulamasi.Data
{
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Öğrencinin İsmi")]
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();

        public string AdSoyad()
        {
           return OgrenciAd + " " + OgrenciSoyad;
        }

    }
}

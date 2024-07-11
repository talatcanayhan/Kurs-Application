using System.ComponentModel.DataAnnotations;

namespace KursUygulamasi.Data
{
    public class KursKayit
    {
        [Key]
        [Display(Name = "Kayıt No")]
        public int KayitId { get; set;}

        public int OgrenciId { get; set;}

        public int KursId { get; set; }

        public Ogrenci Ogrenci { get; set; } = null!;

        [Display(Name = "Kurs Başlığı")]
        public Kurs Kurs { get; set; } = null!;

        public DateTime KayitTarihi { get; set; }
    }
}
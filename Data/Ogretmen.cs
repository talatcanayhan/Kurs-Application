using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursUygulamasi.Data
{
    public class Ogretmen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OgretmenId { get; set; }

        public string? Ad { get; set; }

        public string? Soyad { get; set; }

        public string? Eposta { get; set; }

        public string? Telefon { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime BaslamaTarihi { get; set; }
    }
} 
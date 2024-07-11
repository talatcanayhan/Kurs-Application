using Microsoft.EntityFrameworkCore;

namespace KursUygulamasi.Data
{
    public class KursContext : DbContext
    {
        public KursContext(DbContextOptions<KursContext> options) : base(options)
        {
        }

        public DbSet<Kurs> Kurslar => Set<Kurs>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
    }
}
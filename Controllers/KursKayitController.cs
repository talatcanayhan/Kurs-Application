using KursUygulamasi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace KursUygulamasi.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly KursContext _context;

        public KursKayitController(KursContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _context.KursKayitlari.Include(x => x.Ogrenci).Include(x => x.Kurs).ToListAsync();
            Console.WriteLine(kursKayitlari);
            return View(kursKayitlari);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "Id", "OgrenciAd");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            Console.WriteLine(model.KayitId);
            _context.KursKayitlari.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var kurskayit = await _context.KursKayitlari.FindAsync(id);
            if (kurskayit == null)
            {
                Console.WriteLine(id);
                return NotFound();
            }
            return View(kurskayit);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            var kurskayit = await _context.KursKayitlari.FindAsync(id);
            if(kurskayit == null)
            {
                return NotFound();
            }
            _context.KursKayitlari.Remove(kurskayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
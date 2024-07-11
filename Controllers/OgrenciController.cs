using KursUygulamasi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursUygulamasi.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly KursContext _context;

        public OgrenciController(KursContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // var ogrenciler = _context.Ogrenciler.ToList();
            // Console.WriteLine(ogrenciler.Count());
            // return View(ogrenciler);

            return View(await _context.Ogrenciler.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var ogr = await _context
                                .Ogrenciler
                                .Include(o => o.KursKayitlari)
                                .ThenInclude(o => o.Kurs)
                                .FirstOrDefaultAsync(o => o.Id == id);

            if (ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!_context.Ogrenciler.Any(o => o.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
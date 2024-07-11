using KursUygulamasi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursUygulamasi.Controllers
{
    
    public class OgretmenController: Controller
    {
        private readonly KursContext _context;
        public OgretmenController(KursContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // var ogrenciler = _context.Ogrenciler.ToList();
            // Console.WriteLine(ogrenciler.Count());
            // return View(ogrenciler);
            return View(await _context.Ogretmenler.ToListAsync());
        }


                
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            
            _context.Ogretmenler.Add(model);
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
                                .Ogretmenler
                                .FirstOrDefaultAsync(o => o.OgretmenId == id);

            if (ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ogretmen model)
        {

            if (id != model.OgretmenId)
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
                    if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
                    {
                        Console.WriteLine("why?");
                        return NotFound();
                    }
                    else
                    {
                         Console.WriteLine("why?2");
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

            var ogretmen = await _context.Ogretmenler.FindAsync(id);

            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if(ogretmen == null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
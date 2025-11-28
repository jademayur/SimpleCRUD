using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data;
using System.Threading.Tasks;

namespace SimpleCRUD.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ProductController(AppDbContext appDbContext )
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await appDbContext.Categories.ToListAsync();
            var products = await appDbContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await appDbContext.Categories.ToListAsync();
            return View("AddEdit", new Models.Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Categories = await appDbContext.Categories.ToListAsync();
                await appDbContext.Products.AddAsync(product);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var product = await appDbContext.Products.FindAsync(id);
            ViewBag.Categories = await appDbContext.Categories.ToListAsync();
            if (product == null)
            {
                return NotFound();
            }
            return View("AddEdit", product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                appDbContext.Products.Update(product);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = await appDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

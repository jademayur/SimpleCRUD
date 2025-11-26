using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data;
using SimpleCRUD.Models;

namespace SimpleCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await appDbContext.Categories.ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("AddEdit", new Category());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Category category)
        {
            if (ModelState.IsValid)
            {
                await appDbContext.Categories.AddAsync(category);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = await appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View("AddEdit",category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Category category)
        {
            if (ModelState.IsValid)
            {
                appDbContext.Categories.Update(category);
                await appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = await appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            appDbContext.Categories.Remove(category);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

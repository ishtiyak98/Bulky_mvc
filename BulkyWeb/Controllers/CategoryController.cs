using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Category> Categories = _db.Categories.ToList();
			return View(Categories);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Add(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();

		}

		public IActionResult Edit(int? id)
		{
            if (id==null || id == 0)
            {
				return NotFound();        
            }
			Category category = _db.Categories.Find(id);
            if (category == null)
            {
				return NotFound();
            }
            return View(category);
		}

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}

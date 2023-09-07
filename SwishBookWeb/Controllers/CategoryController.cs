using Microsoft.AspNetCore.Mvc;
using SwishBookWeb.Data;
using SwishBookWeb.Models;

namespace SwishBookWeb.Controllers
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
            // retrieve category, ambil dari db dan akan di convert ke list
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] //not required
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder can't exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                // return redirect to index
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _db.Categories.Find(id);
            // var categoryDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] //not required
        public IActionResult Update(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder can't exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                // return redirect to index
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
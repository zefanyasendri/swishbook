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

        // Create GET
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
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
                TempData["success"] = "Category created successfully";

                // return redirect to index
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Update GET
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

        // Update POST
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
                TempData["success"] = "Category updated successfully";
                // return redirect to index
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Delete GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
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

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //not required
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            // return redirect to index
            return RedirectToAction("Index");
        }
    }
}
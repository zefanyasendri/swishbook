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
    }
}

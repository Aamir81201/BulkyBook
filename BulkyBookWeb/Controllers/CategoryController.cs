using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
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
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }



        // CREATE

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrders.ToString())
            {
                ModelState.AddModelError("name", "Name cannot match exactly with Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Successfully Created Category";
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //UPDATE

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _db.categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrders.ToString())
            {
                ModelState.AddModelError("name", "Name cannot match exactly with Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Successfully Updated Category";
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //DELETE

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDb = _db.categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)  //Cannot create two methods with same name and parameter.
        {
            var categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _db.categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["Success"] = "Successfully Deleted Category";
            return RedirectToAction("Index");
        }
    }
}

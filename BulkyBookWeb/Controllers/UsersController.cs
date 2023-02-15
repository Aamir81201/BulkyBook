using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<User> usersList = _db.users;
            return View(usersList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.users.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Successfully Created Category";
                return Redirect("Index");
            }
            return View();
        }

        //GET
        public IActionResult Edit(int? userId)
        {   
            if(userId == null || userId == 0)
            {
                return NotFound();
            }
            var userDetail = _db.users.Find(userId);
            return View(userDetail);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.users.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Successfully Updated Category";
                return Redirect("Index");
            }
            return View();
        }

        //GET
        public IActionResult Delete(int? userId)
        {
            if (userId == null || userId == 0)
            {
                return NotFound();
            }
            var userDetail = _db.users.Find(userId);
            return View(userDetail);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? userId)
        {
            if (userId == null || userId == 0)
            {
                return NotFound();
            }
            var userDetail = _db.users.Find(userId);
            if(userDetail == null)
            {
                return NotFound();
            }
            _db.users.Remove(userDetail);
            TempData["Success"] = "Successfully Deleted Category";
            _db.SaveChanges();

            return Redirect("Index");
            
        }
    }
}

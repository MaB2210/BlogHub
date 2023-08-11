using BlogHub.Data;
using BlogHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogHub.Controllers
{
  
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET : User/List
        public IActionResult Index()
        {
            return View(_context.userModels.ToList());
            //return View();
            //return Content("User List");
        }

        //GET: User/AddUser
        public IActionResult AddUser()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }

        //POST: User/AddUser

        [HttpPost]
        public IActionResult AddUser(UserModel userModel)
        {
            /*if (ModelState.IsValid)
            {
                _context.userModels.Add(userModel);
                _context.SaveChanges();

                // Redirect to User/Index after successful addition
                return RedirectToAction("Index");
            }

            // If the model state is invalid, return back to the AddUser view with the model
            return View(userModel);*/
            _context.Add(userModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: User/EditUser
        public IActionResult EditUser(int id)
        {
            // Fetch the user from the database by UserId using .Find(id)
            UserModel user = _context.userModels.Find(id);

            if (user != null)
            {
                return View(user); // Pass the user data to the EditUser.cshtml view
            }

            // If the user with the specified ID was not found, you can handle the error accordingly (e.g., return a not found view or redirect to another page).
            // For simplicity, I'm returning a plain text response in this example.
            return Content("User not found");
        }

        //POST: User/EditUser
        [HttpPost]
        public IActionResult EditUser(UserModel um)
        {
            _context.Update(um);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: User/Details
        public IActionResult UserDetails(int id)
        {
            var user = _context.userModels.Find(id);
            return View(user);
        }

        

        //GET : User/Delete
        public IActionResult DeleteUser(int id)
        {
            var user = _context.userModels.Find(id);
            return View(user);
        }

        //POST: User/Delete
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDeleteUser(int id)
        {
            var user = _context.userModels.Find(id);

            if (user == null)
            {
                // User not found, handle this case appropriately (e.g., display an error message)
                return RedirectToAction("Index");
            }

            _context.userModels.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

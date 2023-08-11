using BlogHub.Data;
using BlogHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogHub.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        public readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Blog/Index
        public IActionResult Index()
        {
            return View(_context.blogModels.ToList());
        }
        //GET: Blog/AddBlog
        public IActionResult AddBlog()
        {
            // Fetch all categories from the database
            List<CategoryModel> categories = _context.categoryModels.ToList();

            // Create a SelectList for categories to be used in the view
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");

            return View();
        }

        //POST: Blog/AddBlog

        [HttpPost]
        public IActionResult AddBlog(BlogModel bm)
        {
            _context.Add(bm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Blog/EditBlog
        public IActionResult EditBlog()
        {
            return Content("get edit blog");
        }

        //POST: Blog/EditBlog
        [HttpPost]
        public IActionResult EditUser(BlogModel bm)
        {
            return Content("post User/ edit blog" + bm.GetType);
        }

        //GET: Blog/Details
        public IActionResult Details()
        {
            return Content("get blog/Details");
        }

        //POST: Blog/Details
        [HttpPost]
        public IActionResult Details(BlogModel bm)
        {
            return Content("POST: BLog/Details" + bm.GetType);
        }

        //GET : Blog/Delete
        public IActionResult Delete()
        {
            return Content("get: Blog/delete");
        }

        //POST: User/Delete
        [HttpPost]
        public IActionResult Delete(BlogModel bm)
        {
            return Content("post: Blog/delete" + bm.GetType);
        }
    }
}

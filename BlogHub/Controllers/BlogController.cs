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
            List<UserModel> users = _context.userModels.ToList();


            // Create a SelectList for categories to be used in the view
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            ViewData["Users"] = new SelectList(users, "Userid", "Username");

            var model = new BlogModel(); // Create a new instance of BlogModel
            return View(model); // Pass the model to the view
        }

        //POST: Blog/AddBlog

        [HttpPost]
        public IActionResult AddBlog(BlogModel bm)
        {
            
            BlogModel blog = new BlogModel();
            CategoryModel cat = _context.categoryModels.Find(bm.CategoryId); 
            
            UserModel user = _context.userModels.Find(bm.UserId); 

            blog.Title = bm.Title;
            blog.BlogDescription = bm.BlogDescription;
            blog.Category = cat.Name;
            blog.User = user.Username;

            blog.UserId = user.Userid;
            blog.CategoryId = cat.CategoryId;

            blog.CategoryModel = cat;
            blog.UserModel = user;

            _context.blogModels.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Blog/EditBlog
        public IActionResult EditBlog(int id)
        {
            // Fetch the blog post by its ID
            BlogModel blog = _context.blogModels.Find(id);

            if (blog == null)
            {
                return Content("Blog Not found"); // Return a 404 Not Found if the blog post doesn't exist
            }

            // Fetch all categories from the database
            List<CategoryModel> categories = _context.categoryModels.ToList();
            List<UserModel> users = _context.userModels.ToList();

            // Create a SelectList for categories and users to be used in the view
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            

            return View(blog); // Pass the blog post to the view for editing
         }

        //POST: Blog/EditBlog
        [HttpPost]
        public IActionResult EditBlog(int id,BlogModel bm)
        {
            

            // Set the Category property to the selected CategoryId from the form
            BlogModel blog = _context.blogModels.Find(id);
            CategoryModel cat = _context.categoryModels.Find(bm.CategoryId);
            UserModel user = _context.userModels.Find(bm.UserId);

            if (blog == null || cat == null || user == null)
            {
                return NotFound(); // Return a 404 Not Found if any of the entities don't exist
            }

            // Update the properties of the blog post
            blog.Title = bm.Title;
            blog.BlogDescription = bm.BlogDescription;
            blog.Category = cat.Name;
            blog.User = user.Username;

            blog.UserId = user.Userid;
            blog.CategoryId = cat.CategoryId;

            blog.CategoryModel = cat;
            blog.UserModel = user;

            _context.blogModels.Update(blog);
            _context.SaveChanges(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the blog list after editing
        }

            //GET: Blog/Details
            public IActionResult BlogDetails(int id)
        {
            BlogModel blog = _context.blogModels.Find(id);

            if (blog == null)
            {
                return Content("Details not found");
            }
            return View(blog);
        }

        //GET : Blog/Delete
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.blogModels.Find(id);
            return View(blog);
        }

        //POST: User/Delete
        [HttpPost]
        public IActionResult DeleteBlog(BlogModel bm)
        {
            _context.blogModels.Remove(bm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

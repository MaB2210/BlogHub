using BlogHub.Data;
using BlogHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogHub.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Category/Index
        public IActionResult Index()
        {
            return View(_context.categoryModels.ToList());
        }
        //GET: Category/AddCategory
        public IActionResult AddCategory()
        {
            CategoryModel categoryModel = new CategoryModel();
            return View(categoryModel);
        }

        //POST: Category/AddCategory

        [HttpPost]
        public IActionResult AddCategory(CategoryModel cm)
        {
            _context.Add(cm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Category/EditCategory
        public IActionResult EditCategory(int id)
        {
            // Fetch the category from the database by CategoryId using .Find(id)
            CategoryModel category = _context.categoryModels.Find(id);

            if (category != null)
            {
                return View(category); // Pass the caetgory data to the EditCategory.cshtml view
            }

            // If the category with the specified ID was not found, you can handle the error accordingly (e.g., return a not found view or redirect to another page).
            // For simplicity, I'm returning a plain text response in this example.
            return Content("Category not found");
        }

        //POST: Category/EditCategory
        [HttpPost]
        public IActionResult EditCategory(CategoryModel cm)
        {
            _context.Update(cm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Category/Details
        public IActionResult CategoryDetails(int id)
        {
            var category = _context.categoryModels.Find(id);
            return View(category);
        }

        //GET : Category/Delete
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.categoryModels.Find(id);
            return View(category);
        }

        //POST: Category/Delete
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDeleteCategory(int id)
        {
            var category = _context.categoryModels.Find(id);

            if (category == null)
            {
                // User not found, handle this case appropriately (e.g., display an error message)
                return RedirectToAction("Index");
            }

            _context.categoryModels.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

using BlogHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BlogHub.Models;

namespace BlogHub.Controllers
{
    public class UserViewController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserViewController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<IActionResult> Manage()
        {
            UserViewModel uvm = new UserViewModel();
            uvm.Users = userManager.Users.ToList();
            uvm.Roles = roleManager.Roles.ToList();
            foreach (IdentityUser u in uvm.Users)
            {
                var listOfRoles = await userManager.GetRolesAsync(u);
                uvm.UserRoles.Add(u.UserName, listOfRoles);
            }
            return View(uvm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser usr = await userManager.FindByIdAsync(id);
            if (usr != null)
            {
                await userManager.DeleteAsync(usr);
            }
            return RedirectToAction("Manage");
        }
        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminrole = await roleManager.FindByNameAsync("Admin");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(usr, adminrole.Name);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> AddToBlogger(string id)
        {
            IdentityRole bloggerrole = await roleManager.FindByNameAsync("Blogger");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(usr, bloggerrole.Name);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> AddToViewer(string id)
        {
            IdentityRole viewerrole = await roleManager.FindByNameAsync("Viewer");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(usr, viewerrole.Name);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            IdentityRole adminrole = await roleManager.FindByNameAsync("Admin");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(usr, adminrole.Name);
            return RedirectToAction("Manage");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromBlogger(string id)
        {
            IdentityRole bloggerrole = await roleManager.FindByNameAsync("Blogger");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(usr, bloggerrole.Name);
            return RedirectToAction("Manage");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromViewer(string id)
        {
            IdentityRole viewerrole = await roleManager.FindByNameAsync("Viewer");
            IdentityUser usr = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(usr, viewerrole.Name);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole adminrole = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(adminrole);
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole(string id)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Manage");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBloggerRole(string id)
        {
            await roleManager.CreateAsync(new IdentityRole("Blogger"));
            return RedirectToAction("Manage");
        }
        [HttpPost]
        public async Task<IActionResult> CreateViewerRole(string id)
        {
            await roleManager.CreateAsync(new IdentityRole("Viewer"));
            return RedirectToAction("Manage");
        }

    }
}

using SP_ASPNET_1.DbFiles.Contexts;
using SP_ASPNET_1.DbFiles.Operations;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace SP_ASPNET_1.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly UserAccountOperations _userAccountOperations = new UserAccountOperations();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<AppUser> users = this._userAccountOperations.GetUsers();
            ViewBag.Title = "User Accounts";
            return View(users);
        }

        // GET: UserAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: UserAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            try
            {
                AppUser appUser = new AppUser { UserName = user.UserName, Email = user.Email, PhoneNumber = user.PhoneNumber };
                var result = await this._userAccountOperations.Create(appUser, user.Password);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            AppUser user;

            user = this._userAccountOperations.GetUserById(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUser user)
        {
            try
            {
                AppUser appUser = new AppUser { UserName = user.UserName, Email = user.Email, PhoneNumber = user.PhoneNumber };
                var result = this._userAccountOperations.Update(appUser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

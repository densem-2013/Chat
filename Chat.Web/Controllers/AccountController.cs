using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Chat.Core.DAL;
using Chat.Core.Infrastructure;
using Chat.Web.Models;

namespace Chat.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<ChatUser> _userrepo;

        public AccountController(IRepository<ChatUser> repo)
        {
            _userrepo = repo;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //search user in db
                ChatUser user =
                    _userrepo.Table.ToList().FirstOrDefault(u => u.Email == model.Email && u.PassWord == model.PassWord);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Message");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ChatUser user = _userrepo.Table.ToList().FirstOrDefault(u => u.Email == model.Email);

                if (user == null)
                {
                    // create new user
                    _userrepo.Insert(new ChatUser
                    {
                        Email = model.Email,
                        PassWord = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    });
                    user = _userrepo.Table.ToList().FirstOrDefault(u => u.Email == model.Email);
                    // if user success added in db
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Message");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with same email already exists!");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
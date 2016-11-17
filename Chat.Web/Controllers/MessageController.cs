using System.Web.Mvc;

namespace Chat.Web.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage()
        {
            return View("Index");
        }
        
    }
}
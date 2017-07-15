using System.Web.Mvc;

namespace CrudMVC5AngularJs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contatos()
        {
            return View();
        }
    }
}
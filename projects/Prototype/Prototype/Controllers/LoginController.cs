using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// ログイン画面を制御するコントローラー。
    /// </summary>
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
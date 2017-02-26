using System.Net;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// エラー画面を制御するコントローラー。
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;

            return View();
        }
    }
}
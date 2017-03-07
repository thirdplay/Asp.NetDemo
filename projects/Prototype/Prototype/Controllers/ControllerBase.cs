using log4net;
using OfficeOpenXml;
using Prototype.Attributes;
using Prototype.Services;
using Prototype.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Controllers
{
    /// <summary>
    /// コントローラーの基底クラス。
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// Ajaxエラー時のJSON結果を取得します。
        /// </summary>
        /// <returns>JSON結果</returns>
        protected JsonResult GetJsonResultOfAjaxError()
        {
            var modelState = this.ModelState;
            if (this.Request.IsAjaxRequest() && !modelState.IsValid)
            {
                var errorModel = modelState.Keys
                    .Where(x => modelState[x].Errors.Count > 0)
                    .Select(x => new
                    {
                        key = x,
                        errors = modelState[x].Errors.Select(y => y.ErrorMessage).ToArray()
                    });
                return new JsonResult()
                {
                    Data = new
                    {
                        Result = false,
                        Errors = errorModel
                    }
                };
            }
            return new JsonResult();
        }
    }
}
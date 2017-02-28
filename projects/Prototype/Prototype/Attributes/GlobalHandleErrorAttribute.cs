using log4net;
using System;
using System.Net;
using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Attributes
{
    /// <summary>
    /// 全てのアクションメソッドがスローした例外の処理に使用される属性を表します。
    /// </summary>
    public class GlobalHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 例外が発生したときに呼び出されます。
        /// </summary>
        /// <param name="filterContext">アクションフィルターコンテキスト</param>
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // 例外発生時は常にログを取っておく
            //LogUtil.LogControllerError(filterContext);
            logger.Error(filterContext.Exception.ToString());

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                // Application_Errorは呼ばれない
                HandleAjaxRequestException(filterContext);
            }
            else
            {
                // custom errorが有効でなければ
                // base.OnException()でExceptionHandledがtrueにならないので
                // Application_Errorも呼ばれる
                base.OnException(filterContext);
            }
        }

        /// <summary>
        /// Ajax要求をエラーハンドリングします。
        /// </summary>
        /// <param name="filterContext">アクションフィルターコンテキスト</param>
        private void HandleAjaxRequestException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.Result = new JsonResult
            {
                Data = new
                {
                    Message = filterContext.Exception.ToString()
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
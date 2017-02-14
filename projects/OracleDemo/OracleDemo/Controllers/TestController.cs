using OracleDemo.Models;
using OracleDemo.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics;

namespace OracleDemo.Controllers
{
    /// <summary>
    /// テスト画面を制御するクラスです。
    /// </summary>
    public class TestController : Controller
    {
        /// <summary>
        /// ユーザの業務ロジック。
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="service">ユーザの業務ロジック</param>
        public TestController(UserService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 初期表示。
        /// </summary>
        /// <returns>アクションの結果</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 非同期処理の実行処理。
        /// </summary>
        /// <returns>アクションの結果</returns>
        [HttpPost]
        public async Task<ActionResult> Execute()
        {
            Debug.WriteLine("Execute:Start");
            var result = await Task<ActionResult>.Run(() =>
            {
                Debug.WriteLine("ExecuteTask:Start");
                for (var i = 0; i < 12; i++)
                {
                    Debug.WriteLine("ExecuteTask:Executing...[{0}]", i + 1);
                    var list = this._service.ListAll();
                    Thread.Sleep(1000 * 5);
                }
                Debug.WriteLine("ExecuteTask:End");

                return RedirectToAction("Index");
            });
            Debug.WriteLine("Execute:End");
            return result;
        }
   }
}
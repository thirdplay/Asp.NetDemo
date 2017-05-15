using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Constants;
using Prototype.Mvc.Annotations;
using Prototype.Entities;
using Prototype.Mvc.Interop;
using Prototype.Models;
using Prototype.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using NLog;

namespace Prototype.Services
{
	/// <summary>
	/// テスト解析サービスのインターフェース。
	/// </summary>
	public interface IAnalyzableServiceBase
	{
		/// <summary>
		/// 解析処理。
		/// </summary>
		/// <param name="httpContext">HTTPコンテキスト</param>
		/// <returns>解析結果のファイル名</returns>
		Task<string> Analyze(HttpContextBase httpContext);
	}

	/// <summary>
	/// 解析サービスの基底クラス。
	/// </summary>
	public abstract class AnalyzableServiceBase : IAnalyzableServiceBase, IDisposable
	{
		private Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public AnalyzableServiceBase()
		{
			//this.Logger.Debug($"AnalyzableServiceBase:Constructor");
		}

		/// <summary>
		/// 解析処理。
		/// </summary>
		/// <param name="httpContext">HTTPコンテキスト</param>
		/// <returns>解析結果のファイル名</returns>
		public Task<string> Analyze(HttpContextBase httpContext)
		{
			return Task.Run(() =>
			{
#if true
				logger.Trace(">>解析開始");
				for (var j = 0; j < 30; j++)
				{
					for (var i = 0; i < 60; i++)
					{
						Thread.Sleep(1000);
					}
					logger.Trace($"{(j + 1)}分経過");
				}
				logger.Trace(">>解析終了");

				// InteropExcel
				var resultDir = HostingEnvironment.MapPath("/Common/Result");
				var tempDir = HostingEnvironment.MapPath("/Common/Template");
				using (var excel = new InteropExcel(Path.Combine(tempDir, "prototype.xlsm")))
				{
					excel.Run("ThisWorkbook.TestMacro4", "a1", "a2");

					// 出力
					var fileName = "prototype_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsm";
					excel.SaveAs(Path.Combine(resultDir, fileName));

					return fileName;
				}
#endif
			});
		}

		#region IDispose members

		/// <summary>
		/// このインスタンスによって使用されているリソースを全て破棄します。
		/// </summary>
		public void Dispose()
		{
			//this.Logger.Debug("AnalyzableServiceBase:Dispose");
		}

		#endregion IDispose members
	}
}
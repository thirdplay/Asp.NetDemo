using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Constants;
using Prototype.Mvc.Annotations;
using Prototype.Entities;
using Prototype.Models;
using Prototype.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using NLog;

namespace Prototype.Services
{
	/// <summary>
	/// テスト解析サービスのインターフェース。
	/// </summary>
	[Service(typeof(TestAnalyzableService))]
	public interface ITestAnalyzableService : IAnalyzableServiceBase
	{
	}

	/// <summary>
	/// テスト解析サービス。
	/// </summary>
	public class TestAnalyzableService : AnalyzableServiceBase, ITestAnalyzableService
	{
		/// <summary>
		/// ログインターフェース。
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public TestAnalyzableService(ITestService testService)
			: base(testService)
		{
			logger.Debug($"TestAnalyzableService:Constructor");
		}
	}
}
using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Constants;
using Prototype.Mvc.DI;
using Prototype.Entities;
using Prototype.Models;
using Prototype.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using NLog;

namespace Prototype.Services
{
	/// <summary>
	/// テストサービスのインターフェース。
	/// </summary>
	[Service(typeof(TestService))]
	public interface ITestService
	{
		/// <summary>
		/// テーブル件数を取得します。
		/// </summary>
		/// <returns>テーブル件数</returns>
		int GetTableCount();
	}

	/// <summary>
	/// テストサービス。
	/// </summary>
	public class TestService : ITestService, IDisposable
	{
		/// <summary>
		/// サービスロケーター
		/// </summary>
		private readonly IServiceLocator serviceLocator;

		/// <summary>
		/// テスト用リポジトリ
		/// </summary>
		private ITestRepository testRepository;

		/// <summary>
		/// テストコンポーネント
		/// </summary>
		public ITestComponent TestComponent => this.serviceLocator.GetInstance<ITestComponent>();

		/// <summary>
		/// NLogロガー
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public TestService(IServiceLocator serviceLocator, ITestRepository testRepository)
		{
			this.serviceLocator = serviceLocator;
			this.testRepository = testRepository;
			logger.Debug($"TestService:Constructor");
		}

		/// <summary>
		/// テーブル件数を取得します。
		/// </summary>
		/// <returns>テーブル件数</returns>
		public int GetTableCount()
		{
			return testRepository.CountTable();
		}

		#region IDispose members

		/// <summary>
		/// このインスタンスによって使用されているリソースを全て破棄します。
		/// </summary>
		public void Dispose()
		{
			logger.Debug("TestService:Dispose");
		}

		#endregion IDispose members
	}
}
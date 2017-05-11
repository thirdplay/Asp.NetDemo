using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using Prototype.Entities;
using Dapper;
using Prototype.Mvc.Annotations;
using Prototype.Mvc;
using Prototype.Mvc.Extensions;

namespace Prototype.Repositories
{
	/// <summary>
	/// テスト用のリポジトリインターフェース。
	/// </summary>
	[Repository(typeof(TestRepository))]
	public interface ITestRepository
	{
		/// <summary>
		/// テーブルの件数を取得します。
		/// </summary>
		/// <returns>件数</returns>
		int CountTable();
	}

	/// <summary>
	/// テスト用のリポジトリ。
	/// </summary>
	public class TestRepository : RepositoryBase, ITestRepository
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="serviceLocator">サービスロケーター</param>
		public TestRepository(IServiceLocator serviceLocator)
			: base(serviceLocator)
		{
		}

		/// <summary>
		/// テーブルの件数を取得します。
		/// </summary>
		/// <returns>件数</returns>
		public int CountTable()
		{
			var list = new string[] { "TEST", "M_USER" };
			var sql = @"
select
	count(*)
from
	USER_TABLES
/**where**/";
			var builder = new SqlBuilder();
			var template = builder.AddTemplate(sql);

			for (var i = 0; i < list.Length; i++)
			{
				var name = $"TableName{i}";
				builder.OrWhere($"TABLE_NAME = :{name}", name, list[i]);
			}

			return this.Connection.Query<int>(template.RawSql, template.Parameters).FirstOrDefault();
		}
	}
}
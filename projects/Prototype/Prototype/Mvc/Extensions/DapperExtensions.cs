using Dapper;

namespace Prototype.Mvc.Extensions
{
	/// <summary>
	/// Dapperの拡張機能を提供します。
	/// </summary>
	public static class DapperExtensions
	{
		/// <summary>
		/// Where句にOr条件を追加します。
		/// </summary>
		/// <param name="sqlBuilder">SQLビルダー</param>
		/// <param name="sql">SQL文字列</param>
		/// <param name="name">パラメータ名</param>
		/// <param name="value">パラメータ値</param>
		public static void OrWhere(this SqlBuilder sqlBuilder, string sql, string name, object value)
		{
			var param = new DynamicParameters();
			param.Add(name, value);
			sqlBuilder.OrWhere(sql, param);
		}
	}
}
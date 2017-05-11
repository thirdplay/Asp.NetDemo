using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prototype.Constants
{
	/// <summary>
	/// セッションの値のキーを表します。
	/// </summary>
	public class SessionKey
	{
		/// <summary>
		/// ユーザID
		/// </summary>
		public static readonly string UserId = "UserId";

		#region extensions

		/// <summary>
		/// 抽出条件のセッションキーを作成します。
		/// </summary>
		/// <param name="controllerName">コントローラー名</param>
		/// <returns>セッションキー</returns>
		public static string CreateExtractedCondition(string controllerName)
		{
			return controllerName;
		}

		#endregion extensions
	}
}
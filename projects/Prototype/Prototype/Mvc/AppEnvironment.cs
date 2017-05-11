using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Prototype.Mvc
{
	/// <summary>
	/// 現在の環境に関する情報、およびそれらを操作する手段を提供します。
	/// </summary>
	public class AppEnvironment
	{
		/// <summary>
		/// ログディレクトリ
		/// </summary>
		public static string LogsDir { get; } = HostingEnvironment.MapPath("/Common/Logs");

		/// <summary>
		/// 一時ディレクトリ
		/// </summary>
		public static string TempDir { get; } = HostingEnvironment.MapPath("/Common/Temp");

		/// <summary>
		/// テンプレートディレクトリ
		/// </summary>
		public static string TemplateDir { get; } = HostingEnvironment.MapPath("/Common/Template");

		/// <summary>
		/// アップロードディレクトリ
		/// </summary>
		public static string UploadDir { get; } = HostingEnvironment.MapPath("/Common/Upload");

		/// <summary>
		/// 接続文字列
		/// </summary>
		public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["Prototype"].ConnectionString;

		/// <summary>
		/// 拠点コード
		/// </summary>
		public static string LocationCode { get; } = ConfigurationManager.AppSettings["LocationCode"];
	}
}
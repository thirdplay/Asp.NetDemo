using System.Reflection;
using System.Web.Mvc;

namespace Prototype.Mvc.Annotations
{
	/// <summary>
	/// アクション メソッドの選択に影響する属性を表します。
	/// </summary>
	public class ButtonNameAttribute : ActionMethodSelectorAttribute
	{
		/// <summary>
		/// ボタン名
		/// </summary>
		public string ButtonName { get; set; }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="buttonName">ボタン名</param>
		public ButtonNameAttribute(string buttonName)
		{
			this.ButtonName = buttonName;
		}

		/// <summary>
		/// アクション メソッドの選択が、指定されたコントローラー コンテキストで有効かどうかを判断します。
		/// </summary>
		/// <param name="controllerContext">コントローラー コンテキスト</param>
		/// <param name="methodInfo">アクション メソッドに関する情報</param>
		/// <returns>アクション メソッドの選択が、指定されたコントローラー コンテキストで有効である場合は true。それ以外の場合は false。</returns>
		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
		{
			return controllerContext.Controller.ValueProvider.GetValue(this.ButtonName) != null;
		}
	}
}
using log4net;
using Prototype.Constants;
using Prototype.Mvc.Annotations;
using System;
using System.Reflection;

namespace Prototype.Models
{
    /// <summary>
    /// テストコンポーネントのインターフェース。
    /// </summary>
    [Component(typeof(TestComponent), Lifetime.Request)]
    public interface ITestComponent
    {
        /// <summary>
        /// ID
        /// </summary>
        string Id { get; set; }
    }

    /// <summary>
    /// テストコンポーネント。
    /// </summary>
    public class TestComponent : ITestComponent, IDisposable
    {
        /// <summary>
        /// ログインターフェース
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public TestComponent()
        {
            this.Id = DateTime.Now.Ticks.ToString();
            this.logger.Debug($"TestComponent:Constructor({this.Id})");
        }

        /// <summary>
        /// リソース破棄。
        /// </summary>
        public void Dispose()
        {
            this.logger.Debug($"TestComponent:Dispose({this.Id})");
        }
    }
}
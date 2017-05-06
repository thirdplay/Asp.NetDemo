using NLog;
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
        /// ロギングインターフェース
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

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
            logger.Debug($"TestComponent:Constructor({this.Id})");
        }

        /// <summary>
        /// リソース破棄。
        /// </summary>
        public void Dispose()
        {
            logger.Debug($"TestComponent:Dispose({this.Id})");
        }
    }
}
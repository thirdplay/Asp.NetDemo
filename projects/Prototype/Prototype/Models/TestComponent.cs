using log4net;
using Prototype.Attributes;
using Prototype.Constants;
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
        string Id { get; set; }
    }

    /// <summary>
    /// テストコンポーネント。
    /// </summary>
    public class TestComponent : ITestComponent, IDisposable
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string Id { get; set; }

        public TestComponent()
        {
            this.Id = DateTime.Now.Ticks.ToString();
            logger.Debug($"TestComponent:Constructor({this.Id})");
        }

        public void Dispose()
        {
            logger.Debug("TestComponent:Dispose");
        }
    }
}
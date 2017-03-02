using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Prototype.Models
{
    public interface ITestComponent
    {
        string Id { get; set; }
    }

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

    public class TestComponent2 : ITestComponent, IDisposable
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string Id { get; set; }

        public TestComponent2()
        {
            this.Id = DateTime.Now.Ticks.ToString();
            logger.Debug($"TestComponent2:Constructor({this.Id})");
        }

        public void Dispose()
        {
            logger.Debug("TestComponent2:Dispose");
        }
    }
}
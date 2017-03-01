using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Prototype.Models
{
    public class TestComponent : IDisposable
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
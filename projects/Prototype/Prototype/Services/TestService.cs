using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Prototype.Services
{
    /// <summary>
    /// テスト用サービス。
    /// </summary>
    public class TestService : IDisposable
    {
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TestService()
        {
            logger.Debug("TestService:Constructor");
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            logger.Debug("TestService:Dispose");
        }
    }
}
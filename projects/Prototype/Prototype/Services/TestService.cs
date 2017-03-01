using log4net;
using Microsoft.Practices.ServiceLocation;
using Prototype.Models;
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
        private IServiceLocator serviceLocator;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TestComponent TestComponent
        {
            get
            {
                return this.serviceLocator.GetInstance<TestComponent>();
            }
        }

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public TestService(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
            logger.Debug($"TestService:Constructor");
        }

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            logger.Debug("TestService:Dispose");
        }
    }
}
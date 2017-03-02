using log4net;
using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Attributes;
using Prototype.Constants;
using Prototype.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Prototype.Services
{
    /// <summary>
    /// テストサービスのインターフェース。
    /// </summary>
    [Service(typeof(TestService))]
    public interface ITestService
    {
    }

    /// <summary>
    /// テストサービス。
    /// </summary>
    public class TestService : ITestService, IDisposable
    {
        private IServiceLocator serviceLocator;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// テストコンポーネントを取得します。
        /// </summary>
        public ITestComponent TestComponent
        {
            get
            {
                return this.serviceLocator.GetInstance<ITestComponent>();
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

        #region IDispose members

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            logger.Debug("TestService:Dispose");
        }

        #endregion
    }
}
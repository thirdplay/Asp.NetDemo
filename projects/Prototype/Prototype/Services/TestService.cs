using log4net;
using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Attributes;
using Prototype.Constants;
using Prototype.Entities;
using Prototype.Models;
using Prototype.Repositories;
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
        void TestClob01();
    }

    /// <summary>
    /// テストサービス。
    /// </summary>
    public class TestService : ITestService, IDisposable
    {
        private IClob01Repository clob01Repository;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public TestService(IClob01Repository clob01Repository)
        {
            this.clob01Repository = clob01Repository;
            this.logger.Debug($"TestService:Constructor");
        }

        public void TestClob01()
        {
            Clob01 entity =  this.clob01Repository.Find("1");
            this.logger.Debug("Data:" + entity.Data);
        }

        #region IDispose members

        /// <summary>
        /// このインスタンスによって使用されているリソースを全て破棄します。
        /// </summary>
        public void Dispose()
        {
            this.logger.Debug("TestService:Dispose");
        }

        #endregion
    }
}
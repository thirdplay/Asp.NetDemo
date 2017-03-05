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
        void TestClobTable();
    }

    /// <summary>
    /// テストサービス。
    /// </summary>
    public class TestService : ITestService, IDisposable
    {
        private IClobTable01Repository clobTableRepository;

        /// <summary>
        /// ログインターフェース。
        /// </summary>
        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public TestService(IClobTable01Repository clobTableRepository)
        {
            this.clobTableRepository = clobTableRepository;
            logger.Debug($"TestService:Constructor");
        }

        public void TestClobTable()
        {
            ClobTable01 entity =  this.clobTableRepository.Find("1");
            logger.Debug("Data:" + entity.Data);
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
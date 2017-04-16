using log4net;
using Microsoft.Practices.ServiceLocation;
using OfficeOpenXml;
using Prototype.Constants;
using Prototype.DIAnnotations;
using Prototype.Entities;
using Prototype.Models;
using Prototype.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Prototype.Services
{
    /// <summary>
    /// テスト解析サービスのインターフェース。
    /// </summary>
    [Service(typeof(TestAnalyzableService))]
    public interface ITestAnalyzableService : IAnalyzableServiceBase
    {
    }

    /// <summary>
    /// テスト解析サービス。
    /// </summary>
    public class TestAnalyzableService : AnalyzableServiceBase, ITestAnalyzableService
    {
        /// <summary>
        /// ログインターフェース。
        /// </summary>
        protected ILog Logger { get; } = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public TestAnalyzableService()
        {
            this.Logger.Debug($"TestAnalyzableService:Constructor");
        }
    }
}
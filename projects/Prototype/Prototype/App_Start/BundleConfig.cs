using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Optimization;

namespace Prototype
{
    public class BundleConfig
    {
        // バンドルの詳細については、http://go.microsoft.com/fwlink/?LinkId=301862  を参照してください
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/microsoftajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/MicrosoftAjax.js",
                        "~/Scripts/MicrosoftMvcAjax.js"));

            // 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
            // できたら、http://modernizr.com にあるビルド ツールを使用して、必要なテストのみを選択します。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/non-responsive.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/prototype").Include(
                      "~/Scripts/common.js"));

            // 画面固有スクリプトの登録
            //RegisterBundlesViewScripts(bundles);
        }

        /// <summary>
        /// バンドルに画面固有スクリプトを登録します。
        /// </summary>
        /// <param name="bundles">バンドルの格納先</param>
        private static void RegisterBundlesViewScripts(BundleCollection bundles)
        {
            var files = Directory.GetDirectories(HostingEnvironment.MapPath("~/Scripts"))
                .SelectMany(x => Directory.GetFiles(x))
                .Select(x => new FileInfo(x));
            foreach (var file in files)
            {
                var dirName = file.Directory.Name;
                var baseName = Path.GetFileNameWithoutExtension(file.Name);
                bundles.Add(new ScriptBundle($"~/bundles/{dirName}/{baseName}").Include(
                    $"~/Scripts/{dirName}/{file.Name}"));
            }
        }
    }
}
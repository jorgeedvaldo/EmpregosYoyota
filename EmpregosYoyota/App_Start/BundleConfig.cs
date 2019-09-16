using System.Web;
using System.Web.Optimization;

namespace EmpregosYoyota
{
    public class BundleConfig
    {
        // Para mais informações sobre Bundling, visite http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/site.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/font-awesome.css",
                "~/Content/css/main.css"));
        }
    }
}
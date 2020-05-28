using System.Web;
using System.Web.Optimization;

namespace ADONETWithSqlServerMVCApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery.easing.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/dataTable").Include(
                      "~/Content/DataTable/dataTables.bootstrap4.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                      "~/Scripts/DataTable/jquery.dataTables.min.js",
                      "~/Scripts/DataTable/dataTables.bootstrap4.min.js",
                      "~/Scripts/DataTable/datatables-demo.js"));

            bundles.Add(new StyleBundle("~/Content/Sweetalert").Include(
                      "~/Content/Sweetalert/sweetalert2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Sweetalert").Include(
                      "~/Scripts/Sweetalert/sweetalert2.min.js",
                      "~/Scripts/Sweetalert/sweetalert2.all.min.js"));
        }
    }
}

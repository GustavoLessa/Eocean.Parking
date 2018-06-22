using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Eocean.Parking.Financeiro.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Js").Include(
                "~/Content/plugins/jQuery/jquery.min.js",
                "~/Content/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/Content/plugins/fastclick/fastclick.js",
                "~/Content/dist/js/adminlte.min.js",
                "~/Content/dist/js/demo.js"
                ));

            bundles.Add(new ScriptBundle("~/Css").Include(
                "~/Content/bootstrap/css/bootstrap.min.css",
                "~/Content/dist/css/adminlte.min.css",
                "~/Content/dist/css/skins/_all_skins.min.css"
                ));

            //BundleTable.EnableOptimizations = true;

        }
    }
}
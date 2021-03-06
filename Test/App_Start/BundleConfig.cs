﻿using System.Web;
using System.Web.Optimization;

namespace Test
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.scrollTo-1.4.2-min.js",
                        "~/Scripts/jquery.localscroll-1.2.7-min.js",
                        "~/Scripts/bootstrap-typeahead.js",
                        "~/Scripts/bootstrap-tooltip.js",
                        "~/Scripts/bootstrap-popover.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery.signalR-2.0.0.js",
                        "~/Scripts/jquery.signalR-2.0.0.min.js",
                        "~/signalr/hubs",
                        "~/Scripts/easing.js",
                        "~/Scripts/jquery.ui.totop.js",
                        "~/Scripts/jquery.dotdotdot.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jRating").Include("~/Scripts/jRating.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new StyleBundle("~/bundles/jRating/css").Include("~/Content/jRating.jquery.css"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                        "~/Content/site.css",
                                        "~/Content/bootstrap.css",
                                        "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
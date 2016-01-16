using System.Web.Optimization;

namespace Crawler
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.easy-autocomplete.js",
                        "~/Scripts/jquery.nice-select.js",
                        "~/Scripts/Auto.js",
                        "~/Scripts/DropDownLists.js",
                        "~/Scripts/Grafico.js",
                        "~/Scripts/Graph.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",       
                "~/Scripts/jquery.validate*"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqplotPlugins").Include(
                        "~/Scripts/jqplot/jquery.jqplot.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.barRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasAxisLabelRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.dateAxisRenderer.minjs",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasTextRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.enhancedLegendRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.highlighter.min.js"));

           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/nice-select.css",
                      "~/Content/easy-autocomplete.css",
                      "~/Content/easy-autocomplete.themes.css",
                      "~/Scripts/jqPlot/jquery.jqplot.min.css",
                      "~/Content/site.css"));
        }
    }
}

using System.Web.Optimization;

namespace Crawler
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/ moment-with-locales.min.js",
                        "~/Scripts/jquery.easy-autocomplete.js",
                        "~/Scripts/jquery.nice-select.js",
                        "~/Scripts/sweetalert2.min.js",
                        "~/Scripts/Auto.js",
                        "~/Scripts/DropDownLists.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/graficos").Include(
                "~/Scripts/Grafico.js",
                "~/Scripts/Graph.js"
                       ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery.validate*"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/Mapas").Include(
               "~/Scripts/jquery.vmap.min.js",
               "~/Scripts/jquery.vmap.brazil.js",
               "~/Scripts/Mapa.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/GraficoLinha").Include(
              
              "~/Scripts/GraficoLinha.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/jqplotPlugins").Include(
                        "~/Scripts/jqplot/jquery.jqplot.min.js",
                        "~/Scripts/jqPlot/excanvas.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.barRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.jqplot.BezierCurveRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.jqplot.blockRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.jqplot.bubbleRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.dateAxisRenderer.minjs",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasTextRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasAxisLabelRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasAxisTickRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasOverlay.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.canvasTextRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.enhancedLegendRenderer.min.js",
                        "~/Scripts/jqPlot/plugins/jqplot.highlighter.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/bootstrap-datepicker.pt-BR.min.js",
                      "~/Scripts/Datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/sweetalert2.css",
                      "~/Content/nice-select.css",
                      "~/Content/jqvmap.css",
                      "~/Content/easy-autocomplete.css",
                      "~/Content/easy-autocomplete.themes.css",
                      "~/Content/jquery.jqplot.min.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/site.css"));
        }
    }
}

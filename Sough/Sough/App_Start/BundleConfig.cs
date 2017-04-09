using System.Web;
using System.Web.Optimization;

namespace Sough
{
    public class BundleConfig
    {
        //BundleTable.EnableOptimizations = true;        
        static IItemTransform cssFixer = new CssRewriteUrlTransform();
        // Pour plus d'informations sur Bundling, accédez à l'adresse http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new StyleBundle("~/Content/css_tamp").Include(

                        ));
            bundles.Add(
            new StyleBundle("~/Content/css")
                .Include("~/Content/css/toujjar-theme/bootstrap.css", cssFixer)
                .Include("~/Content/css/toujjar-theme/bootstrap.min.css", cssFixer)
                .Include("~/Content/css/toujjar-theme/bootstrap-select.min.css", cssFixer)
                
            );
            bundles.Add(new StyleBundle("~/Content/featurebox_select").Include(
                        "~/Content/css/toujjar-theme/featurebox_select.css"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/less.min.js"));


            /*Create Page css & js*/
            bundles.Add(new ScriptBundle("~/bundles/create-js").Include(
                        "~/Scripts/create/car_input_data.js",
                        "~/Scripts/create/car-create-js.js"));

            bundles.Add(new StyleBundle("~/Content/create").Include(
                "~/Content/css/create/create.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-1.9.1.js",
                "~/Scripts/jquery/jquery-2.0.0.js"
            ));


            bundles.Add(new StyleBundle("~/Content/search-main-css").Include(
                        "~/Content/css/show-products/search_main.css"));

            bundles.Add(new StyleBundle("~/Content/ads").Include(
                        "~/Content/css/show-products/ads.css"));

            bundles.Add(new StyleBundle("~/Content/show-product").Include(
                        "~/Content/css/show-products/show-product.css"));

            bundles.Add(new ScriptBundle("~/bundles/jq-caresoul").Include(
                "~/Scripts/jquery/jquery-1.9.1.js",
                "~/Scripts/lightslider.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/jqBootstrapValidation.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery-1.6").Include(
                "~/Scripts/jquery/jquery-1.6.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/show-product").Include(
                        "~/Scripts/show/show-product.js"));

            bundles.Add(new ScriptBundle("~/bundles/ads").Include(
                        "~/Scripts/show/ads.js"));

            bundles.Add(new ScriptBundle("~/bundles/select-options").Include(
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/bootstrap/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/create").Include(
                      "~/Scripts/create/validation.js",
                      "~/Scripts/create/create.js"));

            //Extension css
            bundles.Add(new StyleBundle("~/Content/pace").Include(
                        "~/Content/css/module/pace.css"));

            bundles.Add(new StyleBundle("~/Content/popey").Include(
                        "~/Content/css/module/jquery.popeye.css",
                        "~/Content/css/module/jquery.popeye.style.css"));


            // Extension js
            bundles.Add(new ScriptBundle("~/bundles/pace").Include(
                      "~/Scripts/module/pace.js"));

            bundles.Add(new ScriptBundle("~/bundles/options").Include(
                      "~/Scripts/options.js"));

            bundles.Add(new ScriptBundle("~/bundles/popey").Include(
                      "~/Scripts/module/option-plugin-popeye.js",
                      "~/Scripts/module/jquery.popeye-2.0.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/detect-media").Include(
                        "~/Scripts/bootstrap/bootstrap-toolkit.min.js"));

        }
    }
}
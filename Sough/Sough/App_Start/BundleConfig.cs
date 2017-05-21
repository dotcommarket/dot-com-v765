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

            bundles.Add(new StyleBundle("~/Content/css-ar")
                .Include("~/Content/css/toujjar-theme/bootstrap.min.css", cssFixer)
                .Include("~/Content/css/toujjar-theme/bootstrap-rtl.css", cssFixer)

                .Include("~/Content/css/toujjar-theme/bootstrap-select.min.css", cssFixer)
            );

            bundles.Add(new StyleBundle("~/Content/css-fr")
                .Include("~/Content/css/toujjar-theme/bootstrap.min.css", cssFixer)
                .Include("~/Content/css/toujjar-theme/bootstrap.css", cssFixer)
                .Include("~/Content/css/toujjar-theme/bootstrap-select.min.css", cssFixer)
            );

            bundles.Add(new ScriptBundle("~/bundles/js-fr").Include(
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/less.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-ar").Include(
                        "~/Scripts/bootstrap/bootstrap-rtl.js",
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/less.min.js"));

            /*Create Page css & js*/
            bundles.Add(new ScriptBundle("~/bundles/create-js").Include(
                        "~/Scripts/create/car_input_data.js",
                        "~/Scripts/create/car-create-js.js"));

            bundles.Add(new StyleBundle("~/Content/create-fr").Include(
                "~/Content/css/create/create-fr.css"
                ));
            bundles.Add(new StyleBundle("~/Content/create-ar").Include(
                "~/Content/css/create/create-ar.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-1.9.1.js",
                "~/Scripts/jquery/jquery-2.0.0.js"
            ));


            bundles.Add(new StyleBundle("~/Content/search-main-css-ar").Include(
                        "~/Content/css/show-products/search_main-ar.css"));

            bundles.Add(new StyleBundle("~/Content/search-main-css-fr").Include(
                        "~/Content/css/show-products/search_main-fr.css"));

            bundles.Add(new StyleBundle("~/Content/ads-ar").Include(
                        "~/Content/css/show-products/ads-ar.css"));

            bundles.Add(new StyleBundle("~/Content/ads-fr").Include(
                        "~/Content/css/show-products/ads-fr.css"));

            bundles.Add(new StyleBundle("~/Content/show-product-ar").Include(
                        "~/Content/css/show-products/show-product-ar.css"));

            bundles.Add(new StyleBundle("~/Content/show-product-fr").Include(
                        "~/Content/css/show-products/show-product-fr.css"));

            bundles.Add(new ScriptBundle("~/bundles/jq-caresoul").Include(
                "~/Scripts/jquery/jquery-1.9.1.js",
                "~/Scripts/lightslider.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap/bootstrap.min.js",
                        "~/Scripts/jqBootstrapValidation.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery-1.6").Include(
                "~/Scripts/jquery/jquery-1.6.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/show-product-ar").Include(
                        "~/Scripts/show/show-product-ar.js"));
            bundles.Add(new ScriptBundle("~/bundles/show-product-fr").Include(
                        "~/Scripts/show/show-product-ar.fr"));

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

            bundles.Add(new StyleBundle("~/Content/popey-ar").Include(
                        "~/Content/css/module/jquery.popeye.css",
                        "~/Content/css/module/jquery.popeye.style-ar.css"));

            bundles.Add(new StyleBundle("~/Content/popey-fr").Include(
                        "~/Content/css/module/jquery.popeye.css",
                        "~/Content/css/module/jquery.popeye.style-fr.css"));

            // Extension js
            bundles.Add(new ScriptBundle("~/bundles/pace").Include(
                      "~/Scripts/module/pace.js"));

            bundles.Add(new ScriptBundle("~/bundles/options").Include(
                      "~/Scripts/options.js"));

            bundles.Add(new ScriptBundle("~/bundles/popey-ar").Include(
                      "~/Scripts/module/jquery.popeye-2.0.4.min.js",
                      "~/Scripts/module/option-popeye-ar.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/popey-fr").Include(
                      "~/Scripts/module/jquery.popeye-2.0.4.min.js",
                      "~/Scripts/module/option-popeye-fr.js"
                      ));

                     

            bundles.Add(new ScriptBundle("~/bundles/detect-media").Include(
                        "~/Scripts/bootstrap/bootstrap-toolkit.min.js"));

        }
    }
}
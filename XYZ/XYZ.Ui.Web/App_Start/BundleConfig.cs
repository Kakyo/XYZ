using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZ.Ui.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundleCollection)
        {
            bundleCollection.ResetAll();
            bundleCollection.Clear();

            bundleCollection.Add(GetScriptBundle("modernizr", "modernizr-{version}.js"));

            string jquery,react,signalr,bootstrap;
            GetLibraryPaths(out jquery, out react, out signalr, out bootstrap);
            bundleCollection.Add(GetScriptBundle("library", jquery, signalr, bootstrap, react
                , "react/JSXTransformer-{version}.js"));

            bundleCollection.Add(GetStyleBundle("site"
                , "bootstrap/bootstrap.min.css", "bootstrap/bootstrap-theme.min.css", "site.css"));
        }

        private static void GetLibraryPaths(out string jquery, out string react, out string signalr, out string bootstrap)
        {

            jquery
#if DEBUG
 = "jquery/jquery-{version}.js";
#else
                = "jquery/jquery-{version}.min.js";
#endif
            react
#if DEBUG
 = "react/react-{version}.js";
#else
                = "react/react-{version}.min.js";
#endif
            signalr
#if DEBUG
 = "signalr/jquery.signalR-{version}.js";
#else
                = "signalr/jquery.signalR-{version}.min.js";
#endif
            bootstrap
#if DEBUG
 = "bootstrap/bootstrap.js";
#else
                = "bootstrap/bootstrap.min.js";
#endif
        }

        private static Bundle GetScriptBundle(string name, params string[] paths)
        {
            return GetBundle(name, paths, "~/js", "~/Content/Scripts");
        }
        private static Bundle GetStyleBundle(string name, params string[] paths)
        {
            return GetBundle(name, paths, "~/css", "~/Content/Styles");
        }

        private static Bundle GetBundle(string name, string[] paths, string namePrefix, string pathPrefix)
        {
            var bundle = new Bundle(string.Format("{0}/{1}", namePrefix, name));
            foreach (var path in paths)
                bundle.Include(string.Format("{0}/{1}", pathPrefix, path));
            return bundle;
        }
    }
}
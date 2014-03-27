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
            bundleCollection.Add(GetScriptBundle("library", GetJsLibraryPaths()));

            bundleCollection.Add(GetStyleBundle("site"
                , "bootstrap/bootstrap.min.css", "bootstrap/bootstrap-theme.min.css", "site.css"));
        }

        private static string[] GetJsLibraryPaths()
        {
            List<string> paths = new List<string>();

            //  jQuery files
            paths.Add(IfDebug("jquery/jquery-{version}.js"
                , "jquery/jquery-{version}.min.js"));
            //  jQuery files
            paths.Add(IfDebug("jquery/jquery.maskedinput.js"
                , "jquery/jquery.maskedinput.min.js"));

            //  SignalR files
            paths.Add(IfDebug("signalr/jquery.signalR-{version}.js"
                , "signalr/jquery.signalR-{version}.min.js"));

            //  Bootstrap files
            paths.Add(IfDebug("bootstrap/bootstrap.js"
                , "bootstrap/bootstrap.min.js"));

            //  Knockout files
            paths.Add(IfDebug("knockout/knockout-{version}.js"
                , "knockout/knockout-{version}.min.js"));
            paths.Add(IfDebug("knockout/knockout.mapping-latest.js"
                , "knockout/knockout.mapping-latest.min.js"));
            //paths.Add(IfDebug("knockout/knockout.validation.js"
            //    , "knockout/knockout.validation.min.js"));

            return paths.ToArray();
        }

        private static string IfDebug(string isDebug, string notDebug)
        {
#if DEBUG
            return isDebug;
#else
            return notDebug;
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
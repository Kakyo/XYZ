using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace XYZ.Utils.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string Css(this HtmlHelper htmlHelper, params string[] cssClass)
        {
            return string.Join(" ", cssClass);
        }

        //public static MvcHtmlString FieldFor<TModel>(this HtmlHelper<TModel> htmlHelper
        //    , Func<TModel> expr)
        //{
        //    return null;
        //}
        //public static MvcHtmlString FieldFor<TModel>(this HtmlHelper<TModel> htmlHelper
        //    , Func<TModel> expr, string css)
        //{
        //    return null;
        //}

        public static MvcHtmlString Field(this HtmlHelper htmlHelper, string name
            , string css = null)
        {
            return Field(htmlHelper, name, InputType.Text, css);
        }
        public static MvcHtmlString Field(this HtmlHelper htmlHelper, string name
            , InputType inputType, string css = null)
        {
            TagBuilder input = GetTag(name, css, "input", "ipt");
            input.Attributes.Add("type", inputType.ToString().ToLower());
            input.Attributes.Add("name", SafeName(name));
            input.Attributes.Add("placeholder", name);

            return MvcHtmlString.Create(input.ToString());
        }

        private static string SafeName(string name)
        {
            return Regex.Replace(name.ToLower(), "\\s", "", RegexOptions.Compiled);
        }

        private static TagBuilder GetTag(string name, string cssLabel = null
            , string tagName = "div"
            , string tagIdPrefix = "tag"
            , string innerHtml = null)
        {
            TagBuilder tag = new TagBuilder(tagName);
            tag.GenerateId(string.Format("{0}_{1}", tagIdPrefix, name));
            if (!string.IsNullOrEmpty(cssLabel))
                tag.AddCssClass(cssLabel.Trim());

            if (!string.IsNullOrEmpty(innerHtml))
                tag.InnerHtml = innerHtml;

            return tag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvc = System.Web.Mvc;

namespace XYZ.Attributes
{
    public class AuthorizeAttribute : mvc.AuthorizeAttribute
    {
        public static string LoginUrl { get; set; }

        protected override void HandleUnauthorizedRequest(mvc.AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData.Add("RedirectReason", "You are not authorized to access this page.");
            filterContext.Result = new mvc.RedirectResult(LoginUrl);
        }
    }
}

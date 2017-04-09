using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sough
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            //try
            //{
                string lang = null;
                HttpCookie langCookie = Request.Cookies["culture"];
                if (langCookie != null)
                {
                    lang = langCookie.Value;
                }
                else
                {
                    var userLanguage = Request.UserLanguages;
                    var userLang = userLanguage != null ? userLanguage[0] : "";
                    if (userLang != "")
                    {
                        lang = userLang;
                    }
                    else
                    {
                        lang = GererLang.GetDefaultLanguage();
                    }
                }

                new GererLang().setLang(lang);
                return base.BeginExecuteCore(callback, state);
            //}
            //catch (Exception e)
            //{
            //    //return base.BeginExecuteCore(callback, state);
            //    ViewBag.ex = e.Message;
            //    return View("~/Views/Error/Exception.cshtml");
            //}
        }

    }
}

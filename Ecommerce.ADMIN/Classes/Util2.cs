using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Ecommerce.ADMIN.Classes
{
    public static class Util2
    {
        public static void showMessage(Page page, string message, string pageToRedirect = "", string key = "myKey")
        {
            if (String.IsNullOrEmpty(pageToRedirect))
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, "alert('" + message + ".');", true);
            else
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, "alert('" + message + ".');window.location='" + pageToRedirect + "'", true);
        }
    }
}
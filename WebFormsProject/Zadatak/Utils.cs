using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Zadatak
{
    public enum ToastrType
    {
        Info,
        Warning,
        Success,
        Error
    }

    public static class Utils
    {
        public static void ShowToastr(this Control control, string message, ToastrType type)
        {
            ShowToastr(control, null, message, type);
        }

        public static void ShowToastr(this Control control, string title, string message, ToastrType type)
        {
            string toastrFunction;

            switch (type)
            {
                case ToastrType.Info:
                    toastrFunction = "info";
                    break;
                case ToastrType.Warning:
                    toastrFunction = "warning";
                    break;
                case ToastrType.Success:
                    toastrFunction = "success";
                    break;
                case ToastrType.Error:
                    toastrFunction = "error";
                    break;
                default:
                    throw new Exception();
            }

            string script;
            if (!string.IsNullOrEmpty(title))
            {
                script = $"toastr.{toastrFunction}('{message}', '{title}')";
            }
            else
            {
                script = $"toastr.{toastrFunction}('{message}')";
            }

            ScriptManager.RegisterStartupScript(control, control.GetType(), "toastr", script, true);
        }
    }
}
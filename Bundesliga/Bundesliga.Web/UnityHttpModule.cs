using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Bundesliga.Web
{
    public class UnityHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
        }

        public void Dispose()
        {
            // Nothing to dispose
        }

        private static void OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            if (HttpContext.Current.Handler == null)
            {
                return;
            }

            var handler = HttpContext.Current.Handler;
            Global.Container.BuildUp(handler.GetType(), handler, handler.GetType().FullName);
        }
    }
}
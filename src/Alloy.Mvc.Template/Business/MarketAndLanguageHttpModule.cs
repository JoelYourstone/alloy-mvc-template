using System;
using System.Globalization;
using System.Threading;
using System.Web;
using EPiServer.Globalization;

namespace AlloyTemplates.Business
{
    public class MarketAndLanguageHttpModule : IHttpModule
    {
        public void Init(HttpApplication httpApplication)
        {
            httpApplication.BeginRequest += RedirectOnIncorrectUrlAndDetectLanguage;
        }

        public void Dispose() { }

        private void RedirectOnIncorrectUrlAndDetectLanguage(object sender, EventArgs e)
        {
            var newCulture = new CultureInfo("sv-SE");
            ContentLanguage.PreferredCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
        }
    }
}

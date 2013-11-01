using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace CoreExample
{
    public class LifeSpanHandler : ILifeSpanHandler
    {
        public event EventHandler<string> BeforePopup;

        public void OnBeforeClose(IWebBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browser, string url, ref int x, ref int y, ref int width, ref int height)
        {
            if (BeforePopup != null)
            {
                BeforePopup(this, url);
            }
            return true;
        }
    }
}

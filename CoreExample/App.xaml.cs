using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;

namespace CoreExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Cef.Initialize(new CefSettings
            {
                RemoteDebuggingPort = 8080,
                BrowserSubprocessPath = "CefSharp.BrowserSubprocess.exe"
            });

            Console.WriteLine(Cef.IsInitialized);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            Cef.Shutdown();
        }
    }
}

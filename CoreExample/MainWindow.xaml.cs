using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CoreExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dispatcher _uiDispatcher;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;

            _uiDispatcher = Dispatcher.CurrentDispatcher;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var lifeSpanHandler = new LifeSpanHandler();
            lifeSpanHandler.BeforePopup += lifeSpanHandler_BeforePopup;
            //webView.Address = "http://www.google.com";
            webView.LifeSpanHandler = lifeSpanHandler;

            var lifeSpanHandler2 = new LifeSpanHandler();
            lifeSpanHandler2.BeforePopup += lifeSpanHandler2_BeforePopup;
            webView2.Address = "http://www.yahoo.com";
            webView2.LifeSpanHandler = lifeSpanHandler2;
        }

        void lifeSpanHandler_BeforePopup(object sender, string url)
        {
            _uiDispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                webView.Address = url;
            });
        }

        async void lifeSpanHandler2_BeforePopup(object sender, string url)
        {
            _uiDispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate()
            {
                webView2.LoadUrl(url);
            });
        }

        private void ActivateTop_Click(object sender, RoutedEventArgs e)
        {
            webView2.Deactivate();

            webView.LoadUrl("http://www.google.com");
        }

        private void ActivateBottom_Click(object sender, RoutedEventArgs e)
        {
            webView.Deactivate();

            webView2.LoadUrl("http://www.yahoo.com");
        }

        private void Google_Click(object sender, RoutedEventArgs e)
        {
            webView2.LoadUrl("http://www.google.com");
        }
    }
}

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
using System.Threading;
using System.ServiceModel;
using GeoLib.Services;
using System.Diagnostics;
using GeoLib.WindowsHost.Services;

namespace GeoLib.WindowsHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindow MainUI { get; set; }
        public MainWindow ()
        {
            InitializeComponent();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;

            MainUI = this;

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId +
            " | Process " + Process.GetCurrentProcess().Id.ToString();
        }

        ServiceHost _HostGeoManager = null;
        ServiceHost _HostMessageManager=null;

        private void btnStart_Click ( object sender, RoutedEventArgs e )
        {

            _HostGeoManager = new ServiceHost(typeof(GeoManager));
            _HostMessageManager = new ServiceHost(typeof(MessageManager));
           
            _HostGeoManager.Open();
            _HostMessageManager.Open();

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

        }

        private void btnStop_Click ( object sender, RoutedEventArgs e )
        {
            _HostGeoManager.Close();
            _HostMessageManager.Close();

            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        public void ShowMessage ( string message )
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            lblMessage.Content = message + Environment.NewLine + "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId +
                " | Process " + Process.GetCurrentProcess().Id.ToString();
        }
    }
}

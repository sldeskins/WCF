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
using System.Diagnostics;
using GeoLib.Proxies;
using GeoLib.Contracts;
using System.ServiceModel;
using GeoLib.Client.Contracts;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent();

            this.Title = "UI Running on Thread " +
            Thread.CurrentThread.ManagedThreadId + " | Process " + Process.GetCurrentProcess().Id.ToString();

        }

        private void btnGetInfo_Click ( object sender, RoutedEventArgs e )
        {
            if (txtZipCode.Text != "")
            {
                GeoClient proxy = new GeoClient("httpEP");
                ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                if (data != null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;
                }
                proxy.Close();

            }
        }

        private void bthGetZipCodes_Click ( object sender, RoutedEventArgs e )
        {
            if (txtState.Text != "")
            {
                //GeoClient proxy = new GeoClient("httpEP");

                EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
                System.ServiceModel.Channels.Binding binding = new NetTcpBinding();

                GeoClient proxy = new GeoClient(binding, address);

                IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);

                if (data != null)
                {
                    lstZips.ItemsSource = data;
                }

                proxy.Close();
            }
        }

        private void btnMakeCall_Click ( object sender, RoutedEventArgs e )
        {
            ////when endpoint is in appcofig
            // ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");

            ////progammatic configuring endpoint
            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8010/MessageService");
            System.ServiceModel.Channels.Binding binding = new NetTcpBinding();
            ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>(binding, address);

            //
            IMessageService proxy = factory.CreateChannel();

            proxy.ShowMsg(txtMessage.Text);

            factory.Close();

        }
    }
}

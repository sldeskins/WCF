﻿using System;
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
using GeoLib.WindowsHost.Contracts;

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

            _SyncContext = SynchronizationContext.Current;
        }

        ServiceHost _HostGeoManager = null;
        ServiceHost _HostMessageManager = null;

        SynchronizationContext _SyncContext = null;

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

            SendOrPostCallback callback = new SendOrPostCallback(arg =>
            {
                lblMessage.Content = message + Environment.NewLine +
                "( marshalled from thread " + threadId + " to thread " +
                   Thread.CurrentThread.ManagedThreadId +
                    " | Process " + Process.GetCurrentProcess().Id.ToString() + ")";
            });
            _SyncContext.Send(callback, null);
        }

        private void btnInProc_Click ( object sender, RoutedEventArgs e )
        {
            Thread thread = new Thread(() =>
            {

                ChannelFactory<IMessageService> factory = new ChannelFactory<IMessageService>("");

                IMessageService proxy = factory.CreateChannel();

                proxy.ShowMessage(DateTime.Now.ToLongTimeString() + " from in-process call.");

                factory.Close();
            });

            thread.IsBackground = true;
            thread.Start();
        }
    }
}

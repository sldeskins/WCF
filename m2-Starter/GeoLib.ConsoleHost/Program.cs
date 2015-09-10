using GeoLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Channels;
using GeoLib.Contracts;

namespace GeoLib.ConsoleHost
{
    class Program
    {
        static void Main ( string[] args )
        {
            ServiceHost hostGeoManager = new ServiceHost(typeof(GeoManager));

            //////doing this programmatically
            ////            <!--<service name="GeoLib.Services.GeoManager">
            ////  <endpoint address="net.tcp://localhost:8009/GeoService"
            ////            binding="netTcpBinding"
            ////            contract="GeoLib.Contracts.IGeoService"/>
            ////</service>-->
            //string address = "net.tcp://localhost:8009/GeoService";
            //Binding binding = new NetTcpBinding();
            //Type contract = typeof(IGeoService);

            //hostGeoManager.AddServiceEndpoint(contract, binding, address);

            //
            hostGeoManager.Open();


            //---
            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
            hostGeoManager.Close();
        }
    }
}

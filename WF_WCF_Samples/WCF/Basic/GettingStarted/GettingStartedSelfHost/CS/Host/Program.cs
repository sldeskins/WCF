﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Samples.GettingStarted;

namespace Host
{
    class Program
    {// Host the service within this EXE console application.
        static void Main(string[] args)
        {// Create a ServiceHost for the CalculatorService type.
            using (ServiceHost serviceHost =
                   new ServiceHost(typeof(CalculatorService)))
            {
                // Open the ServiceHost to create listeners         // and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}

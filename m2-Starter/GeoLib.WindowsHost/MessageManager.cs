﻿using GeoLib.WindowsHost.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost.Services
{
    [ServiceBehavior(UseSynchronizationContext = false)] 
    public class MessageManager : IMessageService
    {
        public void ShowMessage ( string message )
        {
           MainWindow.MainUI.ShowMessage(message + " | Process "+
            System.Diagnostics.Process.GetCurrentProcess().Id.ToString());
        }
    }
}

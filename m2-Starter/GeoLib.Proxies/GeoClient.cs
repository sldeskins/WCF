﻿using GeoLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace GeoLib.Proxies
{
    public class GeoClient : ClientBase<IGeoService>, IGeoService
    {
        public GeoClient (string endpointName):base(endpointName)
        {

        }

        public ZipCodeData GetZipInfo ( string zip )
        {
            return Channel.GetZipInfo(zip);
        }

        public IEnumerable<string> GetStates ( bool primaryOnly )
        {
            return Channel.GetStates(primaryOnly);
        }

        public IEnumerable<ZipCodeData> GetZips ( string state )
        {
            return Channel.GetZips(state);
        }

        public IEnumerable<ZipCodeData> GetZips ( string zip, int range )
        {
            return Channel.GetZips(zip, range);
        }
    }
}

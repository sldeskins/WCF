using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace GeoLib.Contracts
{
    [DataContract]
    public class ZipCodeData : IExtensibleDataObject
    {
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string ZipCode { get; set; } 


        //keeps for pass through data
        public ExtensionDataObject ExtensionData
        { get; set; }
    }
}

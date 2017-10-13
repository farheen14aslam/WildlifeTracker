using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WildLifeTracker.Models;

namespace WildLifeTracker.Response
{
    /// <summary>
    /// The model is used to create a response for tracking operation
    /// </summary>
    [DataContract]
    public class TrackingInfoResponse
    {
        [DataMember]
        public List<GPSTrackingInfo> gpsTrackingDetails { get; set; }

    }
}
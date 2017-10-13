using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Models
{
    [DataContract]
    public class GPSTrackingInfo
    {
        /// <summary>
        /// The model is for Tracking Information Operations having tracking details.
        /// </summary>
        [DataMember]
        public int trackingId { get; set; }
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
        [DataMember]
        public System.DateTime createdAt { get; set; }
        [DataMember]
        public int animalId { get; set; }

        [DataMember(Name = "gpsDeviceId", IsRequired = false, EmitDefaultValue = false)]
        public string gpsDeviceId { get; set; }

        [DataMember(Name = "categoryId", IsRequired = false, EmitDefaultValue = false)]
        public int categoryId { get; set; }

        [DataMember(Name = "categoryName", IsRequired = false, EmitDefaultValue = false)]
        public string categoryName { get; set; }

        [DataMember(Name = "animalName", IsRequired = false, EmitDefaultValue = false)]
        public string animalName { get; set; }

        [DataMember(Name = "colorIndication", IsRequired = false, EmitDefaultValue = false)]
        public string colorIndication { get; set; }
    }
}
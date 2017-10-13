using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Models
{
    [DataContract]
    public class Animal
    {
        /// <summary>
        /// The model is for Animal Operations having animal Id, name, GPS device ID
        /// </summary>
        [DataMember]
        public int animalId { get; set; }
        [DataMember]
        public string animalName { get; set; }
        [DataMember(Name = "createdAt", IsRequired = false, EmitDefaultValue = false)]
        public System.DateTime createdAt { get; set; }
        [DataMember]
        public string gpsDeviceId { get; set; }
        [DataMember]
        public int categoryId { get; set; }
        [DataMember]
        public string categoryName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Models
{
    [DataContract]
    public class AnimalCount
    {
        /// <summary>
        /// The model is for Animal Count having the details of animals and keep the count of it
        /// </summary>
        [DataMember]
        public int categoryId { get; set; }
        [DataMember]
        public string categoryName { get; set; }
        [DataMember]
        public string colorIndication { get; set; }
        [DataMember]
        public int totalAnimals { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Models
{
    [DataContract]
    public class Category
    {
        /// <summary>
        /// The model is for Category Operations having category Id, name
        /// </summary>
        [DataMember]
        public int categoryId { get; set; }
        [DataMember]
        public string categoryName { get; set; }
        [DataMember]
        public string colorIndication { get; set; }
        [DataMember]
        public string categoryDesc { get; set; }
    }
}
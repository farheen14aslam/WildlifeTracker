using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Response
{
    [DataContract]
    public class Response
    {
        /// <summary>
        /// The model is used to send any messages if needed.
        /// </summary>
        [DataMember(Name = "message", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string message { get; set; }
    }
}
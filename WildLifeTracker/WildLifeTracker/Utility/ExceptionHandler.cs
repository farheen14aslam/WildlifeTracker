using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WildLifeTracker.Utility
{
    [DataContract]
    public class ErrorHandler
    {

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDesc { get; private set; }

        public ErrorHandler(string errorMessage, string errorDescription)
        {
            ErrorInfo = errorMessage;
            ErrorDesc = errorDescription;
        }
    }
}
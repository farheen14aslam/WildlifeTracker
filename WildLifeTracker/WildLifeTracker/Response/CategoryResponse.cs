using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WildLifeTracker.Models;

namespace WildLifeTracker.Response
{
    /// <summary>
    /// The model is used to create a response for category operation
    /// </summary>
    [DataContract]
    public class CategoryResponse : Response
    {
        [DataMember]
        public Category category { get; set; }
        [DataMember]
        public List<Category> categoryList { get; set; }
    }
}
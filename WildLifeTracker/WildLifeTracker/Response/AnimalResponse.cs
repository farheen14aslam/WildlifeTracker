using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WildLifeTracker.Models;

namespace WildLifeTracker.Response
{
    /// <summary>
    /// The model is used to create a response for animal operation
    /// </summary>
    [DataContract] 
    public class AnimalResponse : Response
    {
        [DataMember]
        public Animal animal { get; set; }

        [DataMember]
        public List<Animal> animalList { get; set; }

        [DataMember]
        public List<AnimalCount> totalAnimalDetails { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Animal Response from the services.
    /// </summary>
    class AnimalResponseView
    {
        public Animal animal { get; set; }
        public List<Animal> animalList { get; set; }
        public List<AnimalCategoryCount> totalAnimalDetails { get;set;}
    }
}

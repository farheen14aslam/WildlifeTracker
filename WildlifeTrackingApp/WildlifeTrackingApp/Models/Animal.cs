using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Animal Operations.
    /// </summary>
    class Animal
    {
        public int animalId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        public string gpsDeviceId { get; set; }
        public int totalAnimals { get; set; }
        public string animalName { get; set; }
    }
}

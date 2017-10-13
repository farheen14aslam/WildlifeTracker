using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Animals Count Per Category.
    /// </summary>
    class AnimalCategoryCount
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        public int totalAnimals { get; set; }
    }
}

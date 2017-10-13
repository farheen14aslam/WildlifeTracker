using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Category Response from the service.
    /// </summary>
    class CategoryResponseView
    {
        public Category category { get; set; }
        public List<Category> categoryList { get; set; }
    }
}

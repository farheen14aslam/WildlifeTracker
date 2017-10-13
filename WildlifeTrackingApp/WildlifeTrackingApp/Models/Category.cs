using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Category Operations.
    /// </summary>
    class Category : Response
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        public string categoryDesc { get; set; }
    }
}

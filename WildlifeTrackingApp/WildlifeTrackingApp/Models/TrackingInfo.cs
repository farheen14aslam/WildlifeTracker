using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used forTracking Operations.
    /// </summary>
    class TrackingInfo
    {
        public int trackingId { get; set; }
        public int animalId { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string colorIndication { get; set; }
        public string gpsDeviceId { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}

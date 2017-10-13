using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WildlifeTrackingApp.Models
{
    /// <summary>
    /// The Model is used for Tracking Operations.
    /// </summary>
    class TrackingResponseView
    {
      public List<TrackingInfo> gpsTrackingDetails { get; set; }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildlifeTrackingApp.Models;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp.Delegates
{
    /// <summary>
    /// Class that call server to get the latest positions of different animals.
    /// </summary>
    class TrackingInfoDelegate
    {
        /// <summary>
        /// Gets the latest positions of all animals from all categories from the database through server call.
        /// </summary>
        /// <returns>Returns list of instances of TrackingInfo class.</returns>
        public static List<TrackingInfo> GetLatestPositionOfAllAnimal()
        {
            TrackingResponseView trackingDetails;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.GET_ALL_ANIMALS_LATEST_POSITION_URL;
            string responseString = HttpUtil.HttpGetRequest(URL);
            trackingDetails = JObject.Parse(responseString).ToObject<TrackingResponseView>();
            List<TrackingInfo> allAnimalTrackingDetails = (trackingDetails.gpsTrackingDetails).Cast<TrackingInfo>().ToList();
            return allAnimalTrackingDetails;
        }
        /// <summary>
        /// Gets the latest positions of all animals from a particular category from the database through server call.
        /// </summary>
        /// <returns>Returns list of instances of TrackingInfo class.</returns>
        public static List<TrackingInfo> GetLatestPositionOfAllAnimalPerCategory(int categoryId)
        {
            TrackingResponseView trackingDetails;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.GET_ANIMALS_LATEST_POSITION_PER_CATEGORY_URL + categoryId;
            string responseString = HttpUtil.HttpGetRequest(URL);
            trackingDetails = JObject.Parse(responseString).ToObject<TrackingResponseView>();
            List<TrackingInfo> allAnimalTrackingDetails = (trackingDetails.gpsTrackingDetails).Cast<TrackingInfo>().ToList();
            return allAnimalTrackingDetails;
        }
    }
}

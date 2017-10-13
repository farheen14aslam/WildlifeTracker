using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WildLifeTracker.Models;
using WildLifeTracker.Response;

namespace WildLifeTracker.Services
{
    /// <summary>
    /// The interface exposes all the APIs for tracking details
    /// </summary>
    [ServiceContract]
    public interface ITrackingInfoService
    {
        /// <summary>
        /// Adds a new tracking info.
        /// <param name="gpsDetails">The GPS details to be added</param>
        /// <returns>Returns the gps details for the newly created GPS info or throws Exception if there is error</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/AddTrackingInfo")]
        GPSTrackingInfo AddTracking(GPSTrackingInfo gpsDetails);

        /// <summary>
        /// Retrieves the latest position of the animals for all the category.
        /// <returns>Returns the latest GPS position for all animals in all category</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/getAllAnimalsLatestLocation")]
        TrackingInfoResponse GetAllAnimalsLocation();

        /// <summary>
        /// Retrieves the latest position of the animals when the category is specified.
        /// <param name="categoryId">The category Id</param>
        /// <returns>Returns the latest GPS position for the selected category</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/getEachCategoryAnimalsLatestLocation/{categoryId}")]
        TrackingInfoResponse GetAnimalsLocationPerCategory(string categoryId);

    }
}

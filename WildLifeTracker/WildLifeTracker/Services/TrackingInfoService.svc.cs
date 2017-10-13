using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WildLifeTracker.Models;
using WildLifeTracker.Repository;
using WildLifeTracker.Response;

namespace WildLifeTracker.Services
{
    /// <summary>
    /// Tracking Service to perform different operations.
    /// </summary>
    public class TrackingInfoService : ITrackingInfoService
    {

        TrackingRepo trackingRepo = null;

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public TrackingInfoService()
        {
            log4net.Config.XmlConfigurator.Configure();
            trackingRepo = TrackingRepo.getInstance();
        }

        /// <summary>
        /// Add the tracking info (Location of animal)
        /// </summary>
        /// <param name="animalDetails">The animal details</param>
        /// <returns>The details of animal that is added</returns>
        public GPSTrackingInfo AddTracking(GPSTrackingInfo gpsDetails)
        {
            return trackingRepo.AddNewTrackingDetails(gpsDetails);
        }

        /// <summary>
        /// Retrieves all the animal's latest position for all the categories
        /// </summary>
        /// <returns>Details of animals, category and the tracking information of all the animals in all category</returns>
        public TrackingInfoResponse GetAllAnimalsLocation()
        {
            TrackingInfoResponse trackingDetailsResponse = new TrackingInfoResponse();
            List<GPSTrackingInfo> trackingInfo = trackingRepo.RetrieveAllAnimalsLatestLocation();
            trackingDetailsResponse.gpsTrackingDetails = trackingInfo;
            return trackingDetailsResponse;
        }

        /// <summary>
        /// Retrieves all the animal's latest position for the selected category
        /// </summary>
        /// <returns>Details of animals, category and the tracking information of all the animals in selected category</returns>
        public TrackingInfoResponse GetAnimalsLocationPerCategory(string categoryId)
        {
            TrackingInfoResponse trackingDetailsResponse = new TrackingInfoResponse();
            List<GPSTrackingInfo> trackingInfo = trackingRepo.RetrieveAllAnimalsLatestLocationPerCategory(categoryId);
            trackingDetailsResponse.gpsTrackingDetails = trackingInfo;
            return trackingDetailsResponse;
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using WildLifeTracker.Models;
using WildLifeTracker.Utility;

namespace WildLifeTracker.Repository
{
    /// <summary>
    /// The class is used to store the GPS Location and retrieve the latest position of animals
    /// </summary>
    public class TrackingRepo
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }

        private static TrackingRepo instance = null;
        private static object lockObj = new Object();
        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        private TrackingRepo()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static TrackingRepo getInstance()
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new TrackingRepo();
                }
            }
            return instance;
        }

        /// <summary>
        /// Add a new tracking information(Location of animals when animal moves)
        /// </summary>
        /// <param name="gpsLocationInfo">The GPS location info</param>
        /// <returns>The details of gps tracking info</returns>
        public GPSTrackingInfo AddNewTrackingDetails(GPSTrackingInfo gpsLocationInfo)
        {
            log.Info("Adding a new tracking info : AddNewTrackingDetails with GPS device ID : " + gpsLocationInfo.gpsDeviceId);
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                //Fetches the animal for given device Id 
                var animal = (from p in dbContext.tblanimals where p.gpsDeviceId == gpsLocationInfo.gpsDeviceId select p).FirstOrDefault();
                gpsLocationInfo.animalId = animal.animalId;
                tblgpstracking trackingEntity = JsonConvert.DeserializeObject<tblgpstracking>(JsonConvert.SerializeObject(gpsLocationInfo));
                trackingEntity.createdAt = DateTime.Now;
                //Adds the details to the DB
                dbContext.tblgpstrackings.Add(trackingEntity);
                try
                {
                    // Saves the details in DB
                    dbContext.SaveChanges();
                    if(trackingEntity != null)
                    {
                        gpsLocationInfo.latitude = trackingEntity.latitude;
                        gpsLocationInfo.longitude = trackingEntity.longitude;
                        gpsLocationInfo.animalId = trackingEntity.animalId;
                        gpsLocationInfo.createdAt = trackingEntity.createdAt;
                        gpsLocationInfo.trackingId = trackingEntity.trackingId;
                        
                    }
                    log.Info("The GPS location is successfully saved in the DB.");
                    return gpsLocationInfo;
                }
                //Saves the entries that could not be saved into the DB. It resolves the concurrency exception with Reload
                catch (DbUpdateConcurrencyException Ex)
                {
                    Ex.Entries.Single().Reload();
                    dbContext.SaveChanges();
                    gpsLocationInfo.latitude = trackingEntity.latitude;
                    gpsLocationInfo.longitude = trackingEntity.longitude;
                    gpsLocationInfo.animalId = trackingEntity.animalId;
                    gpsLocationInfo.createdAt = trackingEntity.createdAt;
                    gpsLocationInfo.trackingId = trackingEntity.trackingId;
                    log.Info("The GPS location is successfully saved in the DB.");
                    return gpsLocationInfo;
                }
                catch (Exception e)
                {
                    log.Error("Error in adding the animal : " + e.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error", e.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);

                }

            }


        }


        /// <summary>
        /// Retrieves all the animal's latest position for all the categories
        /// </summary>
        /// <returns>List of Tracking info</returns>
        public List<GPSTrackingInfo> RetrieveAllAnimalsLatestLocation()
        {
            log.Info("Retrieve all the animal's latest position : RetrieveAllAnimalsLatestLocation");
            List<GPSTrackingInfo> latestAnimalPosition = new List<GPSTrackingInfo>();
            using(game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    string query = String.Format("SELECT category.categoryId ,category.categoryName,category.colorIndication,gpsTrack.trackingId,gpsTrack.createdAt,gpsTrack.animalId,gpsTrack.latitude,gpsTrack.longitude,animal.gpsDeviceId FROM tblgpstracking AS gpsTrack INNER JOIN tblanimal AS animal ON gpsTrack.animalId = animal.animalId INNER JOIN tblcategory as category on category.categoryId = animal.categoryId  INNER JOIN ( SELECT trackingId, animalId, MAX( createdAt ) as MaxDate FROM tblgpstracking GROUP BY animalId) AS gpsLoc ON gpsTrack.animalId = gpsLoc.animalId AND gpsTrack.createdAt = gpsLoc.MaxDate");
                    //fetches the GPS location
                    latestAnimalPosition = dbContext.Database.SqlQuery<GPSTrackingInfo>(query).ToList<GPSTrackingInfo>();
                    log.Info("Successfully retrieved the GPS tracking Info");
                    return latestAnimalPosition;
                }
                catch (Exception ex)
                {
                    log.Error("Error in retrieving the tracking info: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.NotFound);
                }
            }
            
        }


        /// <summary>
        /// Retrieves all the animal's latest position per category
        /// </summary>
        /// /// <param name="categoryId">The category id</param>
        /// <returns>List of Tracking info</returns>
        public List<GPSTrackingInfo> RetrieveAllAnimalsLatestLocationPerCategory(string categoryId)
        {
            log.Info("Retrieve all the animal's latest position : RetrieveAllAnimalsLatestLocationPerCategory");
            List<GPSTrackingInfo> latestAnimalPosition = new List<GPSTrackingInfo>();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //fetches the GPS location
                    string query = String.Format("SELECT category.categoryId ,category.categoryName,category.colorIndication,gpsTrack.trackingId,gpsTrack.createdAt,gpsTrack.animalId,gpsTrack.latitude,gpsTrack.longitude,animal.gpsDeviceId, animal.animalName FROM tblgpstracking AS gpsTrack , tblcategory as category, tblanimal as animal where category.categoryId= '{0}'  and category.categoryId = animal.categoryId and animal.animalId = gpsTrack.animalId  group by gpsTrack.animalId order by gpsTrack.createdAt desc", categoryId);
                    latestAnimalPosition = dbContext.Database.SqlQuery<GPSTrackingInfo>(query).ToList<GPSTrackingInfo>();
                    log.Info("Successfully retrieved the GPS tracking Info");
                    return latestAnimalPosition;
                }
                catch (Exception ex)
                {
                    log.Error("Error in retrieving the tracking info: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.NotFound);
                }
            }
        }
    }
}
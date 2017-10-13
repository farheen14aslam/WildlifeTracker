using Newtonsoft.Json;
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
    /// The class is used to fetch the animals details from DB or save it in the DB
    /// </summary>
    public class AnimalRepo
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }
        private static AnimalRepo instance = null;
        private static object lockObj = new Object();
        /// <summary>GetAllAnimals
        /// Constructor that intialize log4net in class
        /// </summary>
        private AnimalRepo()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static AnimalRepo getInstance()
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new AnimalRepo();
                }
            }
            return instance;
        }

        /// <summary>
        /// Add a new animal
        /// </summary>
        /// <param name="animalDetails">The animal details</param>
        /// <returns>the details of animal </returns>
        public Animal CreateNewAnimal(Animal animalDetails)
        {
            log.Info("Adding a new animal : CreateNewAnimal with GPS device ID" +animalDetails.gpsDeviceId);
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            { 
                tblanimal animalEntity = JsonConvert.DeserializeObject<tblanimal>(JsonConvert.SerializeObject(animalDetails));
                animalEntity.createdAt = DateTime.Now;
                dbContext.tblanimals.Add(animalEntity);
                try
                {
                    //Saves the details of the new animal into database
                    dbContext.SaveChanges();
                    //If animal is successfully created
                    if (animalEntity != null)
                    {
                        animalDetails.animalId = animalEntity.animalId;
                        animalDetails.categoryId = animalEntity.categoryId;
                        animalDetails.animalName = animalEntity.animalName;

                    }
                    log.Info("The animal is successfully created and saved in the DB.");
                    return animalDetails;
                }
                //Saves the entries that could not be saved into the DB. It resolves the concurrency exception with Reload
                catch (DbUpdateConcurrencyException Ex)
                {
                    Ex.Entries.Single().Reload();
                    //saves the details to DB
                    dbContext.SaveChanges();
                    animalDetails.animalId = animalEntity.animalId;
                    animalDetails.categoryId = animalEntity.categoryId;
                    animalDetails.animalName = animalEntity.animalName;
                    animalDetails.createdAt = animalEntity.createdAt;
                    log.Info("The animal is successfully created and saved in the DB.");
                    return animalDetails;
                }
                catch (Exception e)
                {
                    log.Error("The animal creation failed:" + e.StackTrace);
                    ErrorHandler customError = new ErrorHandler("Error Info", e.Message);
                    throw new WebFaultException<ErrorHandler>(customError, HttpStatusCode.BadRequest);
                }

            }
        }

        /// <summary>
        /// Retrieves all the animals
        /// </summary>
        /// <returns>List of animals </returns>
        public List<Animal> RetrieveAllAnimals()
        {
            log.Info("Retrieve all the animsl : RetrieveAllAnimals");
            List<Animal> animalList = new List<Animal>();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //fetches the animal from the DB
                    string query = String.Format("SELECT tblanimal.categoryId,tblanimal.gpsDeviceId,tblanimal.animalName,tblanimal.animalId, tblanimal.gpsDeviceId, tblanimal.createdAt, tblcategory.categoryName FROM tblanimal INNER JOIN tblcategory on tblanimal.categoryId = tblcategory.categoryId order by createdAt");
                    animalList  = dbContext.Database.SqlQuery<Animal>(query).ToList<Animal>();
                    log.Info("Successfully retrieved the animal details");
                    return animalList;

                }
                catch (Exception ex)
                {
                    log.Error("Error in retrieving the animals: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.NotFound);

                }

            }
        }

        /// <summary>
        /// Retrieves animal details per category
        /// </summary>
        /// <param name="categoryId">The categoryId</param>
        /// <returns>The list of Animals</returns>
        public List<Animal> RetrieveAnimalDetailsPerCategory(string categoryId)
        {
            log.Info("Retrieve animals with category Id " +categoryId +" : RetrieveAnimalDetailsPerCategory");
            Int32 catId = Convert.ToInt32(categoryId);
            List<Animal> animalList = new List<Animal>();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
               // string sqlQuery = String.Format("SELECT colorIndication, gpsDeviceId, animalId, animalName, categoryName from tblcategory JOIN tblanimal ON tblcategory.categoryId = tblanimal.categoryId where tblanimal.categoryId = '{0}'",catId);
                //dbContext.Database.SqlQuery<Animal>(sqlQuery).ToList<AnimalCategory>();
                //fetaches the animal details
                var animals = from p in dbContext.tblanimals where p.categoryId == catId select p;
                try
                {

                    foreach (tblanimal animal in animals)
                    {
                        Animal animalDetails = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(animal));
                        log.Debug("The animals are" + animalDetails.animalName);
                        animalList.Add(animalDetails);

                    }
                    log.Info("Successfully retrieved the animal details");
                    return animalList;
                }
                catch (Exception ex)
                {
                    log.Error("error in retrieving the animals: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);

                }

            }
        }

        /// <summary>
        /// Deletes animal details
        /// </summary>
        /// <param name="animalId">The animal Id</param>
        /// <returns>The details of deleted animal</returns>
        public Animal DeleteAnimal(string animalId)
        {
            log.Info("Delete animals with animal Id " + animalId + " : DeleteAnimal");
            Int32 animId = Convert.ToInt32(animalId);
            Animal deletedAnimal = new Animal();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //fetches the animal detail
                    tblanimal animal = (from p in dbContext.tblanimals where p.animalId == animId select p).FirstOrDefault<tblanimal>();
                    //If  there is an animal for given animalId
                    if (animal == null)
                    {                       
                        ErrorHandler error = new ErrorHandler("Error Info", "There is no such Animal");
                        throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);
                    }
                    //deletes the animal
                    dbContext.tblanimals.Remove(animal);
                    dbContext.SaveChanges();
                    deletedAnimal = JsonConvert.DeserializeObject<Animal>(JsonConvert.SerializeObject(animal));
                    log.Info("Successfully deleted the animal with animal Id :" + animal.animalId);
                    return deletedAnimal;

                }
                catch (Exception ex)
                {
                    log.Error("Error in deleting the animals: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);
                }
            }
        }

        /// <summary>
        /// Updates an  animal details
        /// </summary>
        /// <param name="animalDetails">The animal details to be deleted</param>
        /// <returns>The details of updated animal</returns>
        public Animal UpdateAnimal(Animal animalDetails)
        {
            log.Info("Updates animals details : UpdateAnimal");
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //fetches the animal details.
                    tblanimal animal = (from c in dbContext.tblanimals where c.animalId == animalDetails.animalId select c).FirstOrDefault<tblanimal>();
                    //if there is such an entry for the animal
                    if (animal == null)
                    {
                        log.Debug("There is no such animal");
                        //if there is no such an entry for the animal
                        ErrorHandler error = new ErrorHandler("Error Info", "There is no such Animal");
                        throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.NotFound);
                        
                    }
                    animal.animalName = animalDetails.animalName;
                    animal.animalId = animalDetails.animalId;
                    animal.gpsDeviceId = animalDetails.gpsDeviceId;
                    dbContext.SaveChanges();
                    log.Info("Successfully updated the animal with animal Id :" + animal.animalId);
                    return animalDetails;



                }
                catch (Exception ex)
                {
                    log.Error("Error in updating the animals: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);

                }

            }
        }

        /// <summary>
        /// Retrieves animal count per category 
        /// </summary>
        /// <param name="animalDetails">The animal details to be deleted</param>
        /// <returns>The details of updated animal</returns>
        public List<AnimalCount> RetrieveAnimalsCountPerCategory(string fromDate, string toDate)
        {
            log.Info("Retrieves the animals details per category : RetrieveAnimalsCountPerCategory");
            List<AnimalCount> animalList = new List<AnimalCount>();
            using(game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //Fetches the details of all animals between the starting and ending period.
                    string sqlQuery = String.Format("SELECT tblcategory.categoryId, tblcategory.colorIndication,tblcategory.categoryName, COUNT(*) as totalAnimals FROM tblanimal INNER JOIN tblcategory ON tblcategory.categoryId = tblanimal.categoryId where DATE(tblanimal.createdAt) >= '{0}' and DATE(tblanimal.createdAt) <= '{1}' GROUP BY tblcategory.categoryId;", fromDate, toDate);
                    animalList = dbContext.Database.SqlQuery<AnimalCount>(sqlQuery).ToList<AnimalCount>();
                    log.Info("Retrieved the details of all animals from : " + fromDate + " to : " + toDate);
                    return animalList;
                }
                catch (Exception ex)
                {
                    log.Error("Error in retrieving the animals count" + ex.StackTrace);
                    ErrorHandler customError = new ErrorHandler("DB error", ex.Message);                   
                    throw new WebFaultException<ErrorHandler>(customError, HttpStatusCode.NotFound);
                }

            }
        }
    }
}

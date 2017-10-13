using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WildLifeTracker.Models;
using WildLifeTracker.Repository;
using WildLifeTracker.Response;
using WildLifeTracker.Utility;

namespace WildLifeTracker.Services
{
    /// <summary>
    /// Animal Service to perform different operations.
    /// </summary>
    public class AnimalService : IAnimalService
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static log4net.ILog Log { get; private set; }
        AnimalRepo animalRepo = null;

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public AnimalService()
        {
            log4net.Config.XmlConfigurator.Configure();
            animalRepo = AnimalRepo.getInstance();
        }

        /// <summary>
        /// Add the animals to the GPS device
        /// </summary>
        /// <param name="animalDetails">The animal details</param>
        /// <returns>The details of animal that is added</returns>
        public AnimalResponse AddAnimal(Animal animalDetails)
        {
            AnimalResponse animalResponse = new AnimalResponse();
            Animal animal = animalRepo.CreateNewAnimal(animalDetails);          
            animalResponse.animal = animal;
            animalResponse.message = "Animal is allocated successfully";
            return animalResponse;            
        }

        /// <summary>
        /// Retrieves all the animals
        /// </summary>
        /// <returns>All the animals</returns>
        public AnimalResponse GetAllAnimals()
        {
            AnimalResponse animalResponse = new AnimalResponse();
            List<Animal> animals = animalRepo.RetrieveAllAnimals();
            animalResponse.animalList = animals;
            return animalResponse;

        }

        /// <summary>
        /// Retrieves the animals per category
        /// </summary>
        /// <param name="categorId">The categoryId</param>
        /// <returns>Details of animals per category</returns>
        public AnimalResponse GetAnimalsPercategory(string categorId)
        {
            AnimalResponse animalResponse = new AnimalResponse();
            List<Animal> animals = animalRepo.RetrieveAnimalDetailsPerCategory(categorId);
            animalResponse.animalList = animals;
            return animalResponse;
        }

        /// <summary>
        /// Deletes  the animals
        /// </summary>
        /// <param name="animalId">The animal id</param>
        /// <returns>Details of animals</returns>
        public AnimalResponse DeleteAnimal(string animalId)
        {
            AnimalResponse animalResponse = new AnimalResponse();
            Animal animal = animalRepo.DeleteAnimal(animalId);
            animalResponse.animal = animal;
            animalResponse.message = "Animal is deleted successfully";
            return animalResponse;

        }

        /// <summary>
        /// Updates an animal details
        /// </summary>
        /// <param name="animalDetails">The animal details</param>
        /// <returns>Details of updated animal</returns>
        public AnimalResponse UpdateAnimal(Animal animalDetails)
        {
            AnimalResponse animalResponse = new AnimalResponse();
            Animal animal = animalRepo.UpdateAnimal(animalDetails);
            animalResponse.animal = animal;
            animalResponse.message = "Animal is updated successfully";
            return animalResponse;
        }

        /// <summary>
        /// Retrieves the animal details per category
        /// </summary>
        /// <param name="fromDate">The from date</param>
        /// <param name="toDate">The end date</param>
        /// <returns>Details of count of animals per category over the duration</returns>
        public AnimalResponse GetAnimalsCountPerCategory(string fromDate, string toDate)
        {
            AnimalResponse animalResponse = new AnimalResponse();
            List<AnimalCount> count = animalRepo.RetrieveAnimalsCountPerCategory(fromDate, toDate);
            animalResponse.totalAnimalDetails = count;
            return animalResponse;
        }
    }
}

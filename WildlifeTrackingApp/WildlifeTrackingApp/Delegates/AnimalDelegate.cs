using Newtonsoft.Json;
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
    /// Class that calls server for adding new animal, getting animal details.
    /// </summary>
    class AnimalDelegate
    {
        /// <summary>
        /// Get call for getting the details of all animals.
        /// </summary>
        /// <returns>Return list of instances of Models.Animal</returns>
        public static List<Models.Animal> GetAllAnimalsAllocated()
        {
            AnimalResponseView allAnimals;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.RETRIEVE_ALL_ANIMAL_URL;
            string responseString = HttpUtil.HttpGetRequest(URL);
            allAnimals = JObject.Parse(responseString).ToObject<AnimalResponseView>();
            List<Models.Animal> animalList = (allAnimals.animalList).Cast<Models.Animal>().ToList();
            return animalList;
        }
        /// <summary>
        /// Post call for adding new animal to the database.
        /// </summary>
        /// <param name="animalDetails">Instances of Models.Animal</param>
        /// <returns>Return instance of Models.Animal</returns>
        public static Models.Animal AddNewAnimal(Models.Animal animalDetails)
        {
            AnimalResponseView allAnimals;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.ADD_NEW_ANIMAL_URL;
            string requestBody = JsonConvert.SerializeObject(animalDetails);
            string responseString = HttpUtil.HttpPostRequest(URL, requestBody);
            allAnimals = JObject.Parse(responseString).ToObject<AnimalResponseView>();
            Models.Animal createdAnimal = allAnimals.animal;
            return createdAnimal;
        }

        /// <summary>
        /// Delete request for deleting the details of a particular animal.
        /// </summary>
        /// <param name="animalId">Id of animal</param>
        /// <returns>Return instance of Models.Animal</returns>
        public static Models.Animal DeleteAnimal(int animalId)
        {
            AnimalResponseView allAnimals;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.DELETE_ANIMAL_URL + animalId;
            string responseString = HttpUtil.HttpDeleteRequest(URL);
            allAnimals = JObject.Parse(responseString).ToObject<AnimalResponseView>();
            Models.Animal deletedAnimal = allAnimals.animal;
            return deletedAnimal;
        }

        /// <summary>
        /// Get call for getting total count of all animals per category.
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Return instance of Models.Animal</returns>
        public static List<Models.AnimalCategoryCount> GetAnimalsCountPerCategory(string fromDate, string toDate)
        {
            AnimalResponseView allAnimals;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.GET_ANIMAL_COUNT_PER_CATEGORY_URL + fromDate + "/" + toDate;
            string responseString = HttpUtil.HttpGetRequest(URL);
            allAnimals = JObject.Parse(responseString).ToObject<AnimalResponseView>();
            List<Models.AnimalCategoryCount> animalList = (allAnimals.totalAnimalDetails).Cast<Models.AnimalCategoryCount>().ToList();
            return animalList;
        }
    }
}

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
    /// The interface exposes all the APIs for animal details
    /// </summary>
    [ServiceContract]
    public interface IAnimalService
    {
        /// <summary>
        /// Adds a new animal.
        /// <param name="animalDetails">The animal details to be added</param>
        /// <returns>Returns the animal details for the newly created animal or throws Exception</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/AddAnimal")]
        AnimalResponse AddAnimal(Animal animalDetails);

        /// <summary>
        /// Retrieves all the animals
        /// <returns>Returns all the animal details</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/getAllAnimals")]
        AnimalResponse GetAllAnimals ();

        /// <summary>
        /// Retrieves all the  animal when categoryId is specified.
        /// <param name="categoryId">the category id</param>
        /// <returns>Returns animal per category</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/animalDetails/?categoryId={categoryId}")]
        AnimalResponse GetAnimalsPercategory(string categoryId);

        /// <summary>
        /// Delete the animal details.
        /// <param name="animalId">the animal id</param>
        /// <returns>Returns the animal details of animal that is deleted</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/deleteAnimal/{animalId}")]
        AnimalResponse DeleteAnimal(string animalId);

        /// <summary>
        /// Update an animal details.
        /// <param name="animalDetails"> the animal details</param>
        /// <returns>Returns the animal details of updated animal</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/updateAnimal")]
        AnimalResponse UpdateAnimal(Animal animalDetails);

        /// <summary>
        /// Update an animal details.
        /// <param name="fromDate">from date</param>
        /// <param name="toDate">to date</param>
        /// <returns>Returns the count of animal per category</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/getAnimalsCountPerCategory/{fromDate}/{toDate}")]
        AnimalResponse GetAnimalsCountPerCategory(string fromDate, string toDate);
    }
}

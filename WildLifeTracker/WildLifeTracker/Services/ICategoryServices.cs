using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WildLifeTracker.Models;
using WildLifeTracker.Response;

namespace WildLifeTracker
{
    /// <summary>
    /// The interface exposes all the APIs for category details
    /// </summary>
    [ServiceContract]
    public interface ICategoryService
    {
        /// <summary>
        /// Adds a new category.
        /// <param name="categoryDetails">The category details to be added</param>
        /// <returns>Returns the category details for the newly created category or throws Exception if there is error</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "v1/addNewCategory")]
        CategoryResponse AddCategory(Category categoryDetails);

        /// <summary>
        /// Retrieves all the categories.
        /// <returns>Returns all the categories details</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "v1/getCategories")]
        CategoryResponse GetCategories();

        /// <summary>
        /// Retrieves  the  category details when categoryId is specified.
        /// <param name="categoryId">the category id</param>
        /// <returns>Returns the categories detail for given category Id</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "v1/categoryDetails/{categoryId}")]
        CategoryResponse GetCategory(string categoryId);

        /// <summary>
        /// Delete the category details.
        /// <param name="categoryId">the category id</param>
        /// <returns>Returns the animal details of animal that is deleted</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/deleteCategory/{categoryId}")]
        CategoryResponse DeleteCategory(string categoryId);

        /// <summary>
        /// Update an category details.
        /// <param name="categoryId"> the category id</param>
        /// /// <param name="categoryDetails"> the category details</param>
        /// <returns>Returns the category details of updated category</returns>
        /// </summary>
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "v1/updateCategory")]
        CategoryResponse UpdateCategory(Category categoryDetails);
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WildlifeTrackingApp.Models;
using WildlifeTrackingApp.Utility;

namespace WildlifeTrackingApp.Delegates
{
    /// <summary>
    /// Class that calls server to get the details about different categories, delete categories,..
    /// </summary>
    class CategoryDelegate
    {
        /// <summary>
        /// Get call for getting details of all categories.
        /// </summary>
        /// <returns>Returns list of instances of Models.Category</returns>
        public static List<Models.Category> GetAllCategories()
        {
            CategoryResponseView allCategories;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.RETRIEVE_ALL_CATEGORY_URL;
            string responseString = HttpUtil.HttpGetRequest(URL);
            allCategories = JObject.Parse(responseString).ToObject<CategoryResponseView>();
            List<Models.Category> categoryList = (allCategories.categoryList).Cast<Models.Category>().ToList();
            return categoryList;
        }
        /// <summary>
        /// Delete call for deleting details of all categories.
        /// </summary>
        /// <param name="categoryId">Unique id cprresponding to each category.</param>
        /// <returns>Returns list of instance of Models.Category</returns>
        public static Models.Category DeleteCategory(int categoryId)
        {
            CategoryResponseView categoryDeleted;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.DELETE_NEW_CATEGORY_URL + categoryId;
            string responseString = HttpUtil.HttpDeleteRequest(URL);
            categoryDeleted = JObject.Parse(responseString).ToObject<CategoryResponseView>();
            Models.Category category = categoryDeleted.category;
            return category;
        }
        /// <summary>
        /// Post call for adding details of new category.
        /// </summary>
        /// <param name="categoryDetails">instances of Models.Category</param>
        /// <returns>Returns list of instance of Models.Category</returns>
        public static Models.Category AddNewCategory(Models.Category categoryDetails)
        {
            CategoryResponseView newCategory;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.ADD_NEW_CATEGORY_URL;
            string requestBody = JsonConvert.SerializeObject(categoryDetails);
            string responseString = HttpUtil.HttpPostRequest(URL, requestBody);
            newCategory = JObject.Parse(responseString).ToObject<CategoryResponseView>();
            Models.Category category = newCategory.category;
            return category;
        }

        /// <summary>
        /// Update call for updating details of category.
        /// </summary>
        /// <param name="categoryId">Unique id cprresponding to each category.</param>
        /// <returns>Returns list of instance of Models.Category</returns>
        public static Models.Category UpdateCategory(Models.Category categoryDetails)
        {
            CategoryResponseView categoryUpdated;
            string URL = System.Configuration.ConfigurationManager.AppSettings["WildLifeTrackerServiceBaseURL"] + Constants.UPDATE_CATEGORY_URL;
            string requestBody = JsonConvert.SerializeObject(categoryDetails);
            string responseString = HttpUtil.HttpPutRequest(URL, requestBody);
            categoryUpdated = JObject.Parse(responseString).ToObject<CategoryResponseView>();
            Models.Category category = categoryUpdated.category;
            return category;
        }

    }
}

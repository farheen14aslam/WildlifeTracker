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

namespace WildLifeTracker
{
    /// <summary>
    /// Category Service to perform different operations.
    /// </summary>
    public class CategoryService : ICategoryService
    {

        CategoryRepo categoryRepo = null;

        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        public CategoryService()
        {
            log4net.Config.XmlConfigurator.Configure();
            categoryRepo = CategoryRepo.getInstance();
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        /// <param name="categoryDetails">The category details</param>
        /// <returns>The created category details</returns>
        public CategoryResponse AddCategory(Category categoryDetails)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            Category category = categoryRepo.CreateNewCategory(categoryDetails);
            categoryResponse.category = category;
            categoryResponse.message = "Category is added succefully";
            return categoryResponse;
        }

        /// <summary>
        /// Deletes  the category
        /// </summary>
        /// <param name="categoryId">The category id</param>
        /// <returns>Details of category deleted</returns>
        public CategoryResponse DeleteCategory(string categoryId)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            Category category = categoryRepo.DeleteCategory(categoryId);         
            categoryResponse.category = category;
            categoryResponse.message = "Deleted Animal Successfully";
            return categoryResponse;
            
            
        }

        /// <summary>
        /// Retrieve all the categories
        /// </summary>
        /// <returns>Details of all the categories</returns>
        public CategoryResponse GetCategories()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            List<Category> categoryList = categoryRepo.RetrieveAllCategories();
            categoryResponse.categoryList = categoryList;
            return categoryResponse;
        }

        /// <summary>
        /// Retrieve category details of selected category
        /// </summary>
        /// <param name="categoryId">The category id</param>
        /// <returns>Details of all the category for selected category type</returns>
        public CategoryResponse GetCategory(string categoryId)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            Category category = categoryRepo.RetrieveCategory(categoryId);
            categoryResponse.category = category;
            categoryResponse.message = "Fetching of categories";
            return categoryResponse;

        }

        /// <summary>
        /// Upadtes the category
        /// </summary>
        /// <param name="categoryId">The category id</param>
        /// <param name="categoryDetails">The category details</param>
        /// <returns>Details of the updated category</returns>
        public CategoryResponse UpdateCategory(Category categoryDetails)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            Category category = categoryRepo.UpdateCategory(categoryDetails);
            categoryResponse.category = category;
            categoryResponse.message = "Successfully updated the category";
            return categoryResponse;
        }
    }
}

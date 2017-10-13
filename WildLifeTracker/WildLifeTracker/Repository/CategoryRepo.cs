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
    /// This class is used to add, update, delete and retrieve the category details.
    /// </summary>
    public class CategoryRepo
    {
        //Configures log4net in class
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
       (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CategoryRepo instance = null;
        private static object lockObj = new Object();
        /// <summary>
        /// Constructor that intialize log4net in class
        /// </summary>
        private CategoryRepo()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static CategoryRepo getInstance()
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new CategoryRepo();
                }
            }
            return instance;
        }


        /// <summary>
        /// This method is used to add a new Category to the database.
        /// </summary>
        /// <param name="categoryDetails">The category details to be saved to the DB</param>
        /// <returns>The success message along with the category details added to the DB</returns>
        public Category CreateNewCategory(Category categoryDetails)
        {
            log.Info("Adding a new category : CreateNewCategory with category name : "+categoryDetails.categoryName);
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                tblcategory categoryEntity = JsonConvert.DeserializeObject<tblcategory>(JsonConvert.SerializeObject(categoryDetails));
                dbContext.tblcategories.Add(categoryEntity);
                try
                {
                    //save the category details in the DB
                    dbContext.SaveChanges();
                    if (categoryEntity == null)
                    {
                        ErrorHandler customError = new ErrorHandler("Error Info", "Category not created");
                        throw new WebFaultException<ErrorHandler>(customError, HttpStatusCode.BadRequest);

                    }
                    categoryDetails.categoryId = categoryEntity.categoryId;
                    categoryDetails.categoryDesc = categoryEntity.categoryDesc;
                    log.Info("The category is successfully created and saved in the DB. with category id" + categoryDetails.categoryId);
                    return categoryDetails;

                }
                //Saves the entries that could not be saved into the DB. It resolves the concurrency exception with Reload
                catch (DbUpdateConcurrencyException Ex)
                {
                    Ex.Entries.Single().Reload();
                    //saves the details to DB
                    dbContext.SaveChanges();
                    categoryDetails.categoryId = categoryEntity.categoryId;
                    categoryDetails.categoryDesc = categoryEntity.categoryDesc;
                    log.Info("The category is successfully created and saved in the DB. with category id" + categoryDetails.categoryId);
                    return categoryDetails;
                }
                catch (Exception e)
                {
                    log.Error("The category creation failed:" + e.StackTrace);
                    ErrorHandler customError = new ErrorHandler("DB error", e.Message);
                    throw new WebFaultException<ErrorHandler>(customError, HttpStatusCode.BadRequest);
                }

            }
        }

        /// <summary>
        /// This method is used to retrieve all the categories from the database.
        /// </summary>
        /// <returns>The list of categories fetched from the DB</returns>
        public List<Category> RetrieveAllCategories()
        {
            log.Info("Retrieve all the categories : RetrieveAllCategories");
            List<Category> categoryList = new List<Category>();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //Fetches the category details from DB
                    var categories = from p in dbContext.tblcategories select p;
                    foreach (tblcategory category in categories)
                    {
                        Category categoryDetails = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(category));
                        log.Debug("The category is" + categoryDetails.categoryName);
                        categoryList.Add(categoryDetails);
                    }
                    log.Info("Successfully retrieved the category details");
                    return categoryList;

                }
                catch(Exception ex)
                {
                    log.Error("Error in retrieving the categories: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.NotFound);

                }
                
            }
            
        }

        /// <summary>
        /// This method is used to retrieve the category detail for the specified categoryId.
        /// </summary>
        /// /// <param name="categoryId">The category id for which the details need to be fetched</param>
        /// <returns>The category details for the specified category Id</returns>
        public Category RetrieveCategory(string categoryId)
        {
            log.Info("Retrieve category details for " +categoryId+"  : RetrieveAllCategories");
            Int32 catId = Convert.ToInt32(categoryId);
            Category categoryDetails;
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //Fetches the category details from DB
                    var category = (from p in dbContext.tblcategories where p.categoryId == catId select p).SingleOrDefault();
                    categoryDetails = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(category));
                    log.Info("Successfully retrieved the category details for category Id "+categoryId);
                    return categoryDetails;
                }
                catch(Exception ex)
                {

                    log.Error("Error in retrieving the category for category Id " +categoryId);
                    ErrorHandler error = new ErrorHandler("Error Info", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);

                }
                        
            }

        }

        /// <summary>
        /// This method is used to delete the category detail for the specified categoryId.
        /// </summary>
        /// <param name="categoryId">The category id for which the details need to be fetched</param>
        /// <returns>The category details for the specified category Id</returns>
        public Category DeleteCategory(string categoryId)
        {
            log.Info("Delete category details for " + categoryId + "  : DeleteCategory");
            Int32 catId = Convert.ToInt32(categoryId);
            Category deletedCategory = new Category();
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {
                    //Fetches the animals to see if any animal is associated with the category
                    Int32 categoryCount = (from p in dbContext.tblanimals where p.categoryId == catId select p).Count();
                    if(!categoryCount.Equals(0) && categoryCount>0)
                    {
                        ErrorHandler error = new ErrorHandler("Error Info", "Animal is associated with a category");
                        throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);
                    }
                    // If no animals are added to the category
                    tblcategory category = (from p in dbContext.tblcategories where p.categoryId == catId select p).FirstOrDefault<tblcategory>();
                    //Removes the animal from DB
                    dbContext.tblcategories.Remove(category);
                    dbContext.SaveChanges();
                    deletedCategory = JsonConvert.DeserializeObject<Category>(JsonConvert.SerializeObject(category));
                    log.Info("Successfully deleted the cateogry with category Id :" + deletedCategory.categoryId);
                    return deletedCategory;
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
        /// This method is used to update the category detail for the specified categoryId.
        /// </summary>
        /// <param name="categoryId">The category id for which the details need to be fetched</param>
        /// <param name="categoryDetails">The category details that need to be updated</param>
        /// <returns>The updated category details</returns>
        public Category UpdateCategory(Category categoryDetails)
        {
            log.Info("Update category details for " + categoryDetails.categoryId + "  : UpdateCategory");
            using (game_reserve_dbEntities dbContext = new game_reserve_dbEntities())
            {
                try
                {   //fetches the category details
                    tblcategory category = (from c in dbContext.tblcategories where c.categoryId == categoryDetails.categoryId select c).FirstOrDefault<tblcategory>();
                    if (category == null)
                    {
                        ErrorHandler error = new ErrorHandler("Error Info","There is no such category");
                        throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);
                    }
                    category.categoryName = categoryDetails.categoryName;
                    category.categoryDesc = categoryDetails.categoryDesc;
                    category.colorIndication = categoryDetails.colorIndication;
                    dbContext.SaveChanges();
                    log.Info("Successfully updated category details for category with category id: " + categoryDetails.categoryId);
                    return categoryDetails;

                }
                catch(Exception ex)
                {
                    log.Error("Error in deleting the category: " + ex.StackTrace);
                    ErrorHandler error = new ErrorHandler("ErrorInfo", ex.Message);
                    throw new WebFaultException<ErrorHandler>(error, HttpStatusCode.BadRequest);

                }

            }

        }
    }
}
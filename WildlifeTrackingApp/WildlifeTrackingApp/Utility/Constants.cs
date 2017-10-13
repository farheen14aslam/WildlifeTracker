using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildlifeTrackingApp.Utility
{
    class Constants
    {
        // HASH_CONSTANT 
        public static string HASH_CONSTANT = "#";

        // COLON_CONSTANTS 
        public static string COLON_CONSTANTS = ":";

        // X86_CONSTANT 
        public static string X86_CONSTANT = "X6";

        // GREEN_COLOR 
        public static string GREEN_COLOR = "green";

        // DATE_PICKER_FOMAT 
        public static string DATE_PICKER_FOMAT = "yyyy-MM-dd";

        // COUNT 
        public static string COUNT = "Count";

        // ALL 
        public static string ALL = "All";

        // ADD_NEW_ANIMAL_URL 
        public static string ADD_NEW_ANIMAL_URL = "Services/AnimalService.svc/v1/AddAnimal";

        // ADD_NEW_ANIMAL_URL 
        public static string UPDATE_CATEGORY_URL = "Services/CategoryService.svc/v1/updateCategory";

        // RETRIEVE_ALL_ANIMAL_URL 
        public static string RETRIEVE_ALL_ANIMAL_URL = "Services/AnimalService.svc/v1/getAllAnimals";

        // DELETE_ANIMAL_URL 
        public static string DELETE_ANIMAL_URL = "Services/AnimalService.svc/v1/deleteAnimal/";

        // GET_ANIMAL_COUNT_PER_CATEGORY_URL
        public static string GET_ANIMAL_COUNT_PER_CATEGORY_URL = "Services/AnimalService.svc/v1/getAnimalsCountPerCategory/";

        // RETRIEVE_ALL_CATEGORY_URL
        public static string RETRIEVE_ALL_CATEGORY_URL = "Services/CategoryService.svc/v1/getCategories";

        // DELETE_NEW_CATEGORY_URL 
        public static string DELETE_NEW_CATEGORY_URL = "Services/CategoryService.svc/v1/deleteCategory/";

        // ADD_NEW_CATEGORY_URL 
        public static string ADD_NEW_CATEGORY_URL = "Services/CategoryService.svc/v1/addNewCategory";

        // GET_ALL_ANIMALS_LATEST_POSITION_URL 
        public static string GET_ALL_ANIMALS_LATEST_POSITION_URL = "Services/TrackingInfoService.svc/v1/getAllAnimalsLatestLocation";

        // GET_ANIMALS_LATEST_POSITION_PER_CATEGORY_URL 
        public static string GET_ANIMALS_LATEST_POSITION_PER_CATEGORY_URL = "Services/TrackingInfoService.svc/v1/getEachCategoryAnimalsLatestLocation/";

        // CATEGORY_ID 
        public static string CATEGORY_ID = "categoryId";

        // CATEGORY_NAME 
        public static string CATEGORY_NAME = "CategoryName";

        // MANDATORY_FIELD_ERROR_MESSAGE 
        public static string MANDATORY_FIELD_ERROR_MESSAGE = "Mandatory fields need not be empty";

        // SUCCESSFUL_ADD_CATEGORY_MESSAGE 
        public static string SUCCESSFUL_ADD_CATEGORY_MESSAGE = "Successfully Added the Category";

        // SUCCESSFUL_DELETE_CATEGORY_MESSAGE 
        public static string SUCCESSFUL_DELETE_CATEGORY_MESSAGE = "Successfully deleted the Category";

        // ERROR_CREATING_CATEGORY_MESSAGE 
        public static string ERROR_CREATING_CATEGORY_MESSAGE = "Error in creating the Category";

        // ERROR_DELETING_CATEGORY_MESSAGE 
        public static string ERROR_DELETING_CATEGORY_MESSAGE = "Error in deleting the category. Please delete animals in case if associated.";

        // SUCCESSFULL_GPS_ALLOCATION_MESSAGE 
        public static string SUCCESSFULL_GPS_ALLOCATION_MESSAGE = "Successfully added the animal and allocated with the GPS Device";

        // ERROR_GPS_ALLOCATION_MESSAGE 
        public static string ERROR_GPS_ALLOCATION_MESSAGE = "Error in allocating the animal with GPS Device";

        // SUCCESSFUL_ANIMAL_DELETING_MESSAGE 
        public static string SUCCESSFUL_ANIMAL_DELETING_MESSAGE = "Animal is deleted successfully";

        // ERRORL_ANIMAL_DELETING_MESSAGE 
        public static string ERROR_ANIMAL_DELETING_MESSAGE = "Error in deleting animal. Cannot delete in order to track the history of Animal";

        // LOCATE_ANIMAL_HEADING_START 
        public static string LOCATE_ANIMAL_HEADING_START = "Locating the animals of ";

        // LOCATE_ANIMAL_HEADING_END_ALL_CATEGORY 
        public static string LOCATE_ANIMAL_HEADING_END_ALL_CATEGORY = " categories";

        // LOCATE_ANIMAL_HEADING_END_PER_CATEGORY 
        public static string LOCATE_ANIMAL_HEADING_END_PER_CATEGORY = " category";

        // COUNT_OF_ALL_THE_ANIMALS_PER_CATEGORY 
        public static string COUNT_OF_ALL_THE_ANIMALS_PER_CATEGORY = "COUNT OF ALL THE ANIMALS PER CATEGORY";

        //TO_DATE_VALIDATION_MESSAGE
        public static string TO_DATE_VALIDATION_MESSAGE = "End date cannot be greater than present date";

        //FROM_DATE_VALIDATION_MESSAGE
        public static string FROM_DATE_VALIDATION_MESSAGE = "From date should be less than present date/end date";

        //SUCCESSFUL_UPDATED_CATEGORY_MESSAGE
        public static string SUCCESSFUL_UPDATED_CATEGORY_MESSAGE = "Category is Successfully Updated.";

        //ERROR_UPDATING_CATEGORY_MESSAGE
        public static string ERROR_UPDATING_CATEGORY_MESSAGE = "Error in updating category.";

        //Predefined color of the Map coordinators by GMap
        public static  string[] CategoryMapLocatorColor = {
              "lightblue",
              "orange",
              "pink",
              "red",
              "green",
              "yellow",
              "purple",
              "orange_small",
              "orange_dot",
              "arrow",
              "black_small",
              "pink_dot",
              "pink_pushpin",             
              "purple_small",
              "purple_dot",
              "purple_pushpin",
              "lightblue_dot",
              "lightblue_pushpin",             
              "red_small",
              "red_dot",
              "red_pushpin",
              "red_big_stop",
              "white_small",            
              "blue_dot",
              "orange",
              "blue",
              "blue_small",
              "blue_pushpin",
              "brown_small",
              "gray_small",             
              "green_small",
              "green_dot",
              "green_pushpin",
              "green_big_go",              
              "yellow_small",
              "yellow_dot",
              "yellow_big_pause",
              "yellow_pushpin",
        };

    }
}

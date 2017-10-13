using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLifeTracker.Models;
using WildLifeTracker.Response;

namespace WildLifeTrackerTest.MockedModels
{
    
    class MockedDataSet
    {
        Category category = new Category();
        CategoryResponse categoryResponse = new CategoryResponse();
        Animal animal = new Animal();
        List<GPSTrackingInfo> gpsTrackingInfo = new List<GPSTrackingInfo>();
        GPSTrackingInfo gpsDetails = new GPSTrackingInfo();
        TrackingInfoResponse gPSTrackingResponse = new TrackingInfoResponse();
        AnimalResponse animalResponse = new AnimalResponse();

        public Category getCategoryDataSet()
        {
            category.categoryId = 1;
            category.categoryName = "Test";
            category.categoryDesc = "This is the test category created";
            category.colorIndication = "#8B6089";
            return category;
        }
        public List<Category> getCategoryListDataSet()
        {
            List<Category> category = new List<Category>();
            category[0].categoryId = 1;
            category[0].categoryName = "Test";
            category[0].categoryDesc = "This is the test category created";
            category[0].colorIndication = "#8B6089";
            return category;
        }

        public CategoryResponse getMockedCategoryResponse()
        {
            categoryResponse.category = getCategoryDataSet();
            return categoryResponse;
        }

        public TrackingInfoResponse getGPSTrackingResponse()
        {
            gPSTrackingResponse.gpsTrackingDetails = getGPSListInfo();
            return gPSTrackingResponse;
        }


        public CategoryResponse getMockedCategoryListResponse()
        {
            categoryResponse.categoryList = getCategoryListDataSet();
            return categoryResponse;
        }

        public TrackingInfoResponse getTrackingInfoResponse()
        {
            gPSTrackingResponse.gpsTrackingDetails = getGPSListInfo();
            return gPSTrackingResponse;
        }

        public Animal getAnimalDataSet()
        {
            animal.animalId = 1;
            animal.animalName = "Test";
            animal.gpsDeviceId = "TestGPS";
            animal.categoryName = "Test";
            return animal;
        }

        public List<Animal> getAnimalListDataSet()
        {
            List<Animal> animals  = new List<Animal>();
            animals[0].animalId = 1;
            animals[0].animalName = "Test";
            animals[0].gpsDeviceId = "TestGPS";
            animals[0].categoryName = "Test";
            return animals;
        }

        public List<GPSTrackingInfo> getGPSListInfo()
        {

            gpsTrackingInfo[0].gpsDeviceId = "TestGPS";
            gpsTrackingInfo[0].latitude = -33.236;
            gpsTrackingInfo[0].longitude = 8.126;
            gpsTrackingInfo[0].categoryName = "Test";
            gpsTrackingInfo[0].trackingId = 1;
            return gpsTrackingInfo;
        }

        public GPSTrackingInfo getGPSDetails()
        {
            gpsDetails.gpsDeviceId = "TestGPS";
            gpsDetails.latitude = -33.236;
            gpsDetails.longitude = 8.126; ;
            return gpsDetails;
        }
    }
}

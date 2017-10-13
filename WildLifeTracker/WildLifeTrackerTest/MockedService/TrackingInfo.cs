using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLifeTracker.Repository;
using WildLifeTracker.Response;
using WildLifeTracker.Services;
using WildLifeTrackerTest.MockedModels;

namespace WildLifeTrackerTest.MockedService
{
    [TestFixture]
    public class TrackingInfo
    {
        Mock<TrackingRepo> trackingInfo = new Mock<TrackingRepo>();
        MockedDataSet dataSet = new MockedDataSet();
        [Test]
        public void AddTrackingInfoTest()
        {
            TrackingInfoService service = new TrackingInfoService();
            trackingInfo.Setup(t => t.AddNewTrackingDetails(dataSet.getGPSDetails())).Returns(dataSet.getGPSDetails());
            var response = service.AddTracking(dataSet.getGPSDetails());
            Assert.AreEqual("1", response.trackingId);

        }

        [Test]
        public void GetAnimalsInAllCategory()
        {
            TrackingInfoService service = new TrackingInfoService();
            trackingInfo.Setup(t => t.RetrieveAllAnimalsLatestLocation()).Returns(dataSet.getGPSListInfo());
            TrackingInfoResponse response = service.GetAllAnimalsLocation();
            Assert.IsTrue(response.gpsTrackingDetails.Count > 0);

        }

        [Test]
        public void GetAnimalsInEachCategory()
        {
            TrackingInfoService service = new TrackingInfoService();
            trackingInfo.Setup(t => t.RetrieveAllAnimalsLatestLocationPerCategory("1")).Returns(dataSet.getGPSListInfo());
            TrackingInfoResponse response = service.GetAllAnimalsLocation();
            Assert.IsTrue(response.gpsTrackingDetails.Count > 0);

        }
    }
}

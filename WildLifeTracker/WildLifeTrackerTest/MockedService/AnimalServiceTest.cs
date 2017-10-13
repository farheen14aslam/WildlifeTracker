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
    public class AnimalServiceTest
    {
        Mock<AnimalRepo> animal = new Mock<AnimalRepo>();
        MockedDataSet dataSet = new MockedDataSet();

        [Test]
        public void AddNewAnimalTest()
        {
            AnimalService service = new AnimalService();
            animal.Setup(t => t.CreateNewAnimal(dataSet.getAnimalDataSet())).Returns(dataSet.getAnimalDataSet());
            AnimalResponse response = service.AddAnimal(dataSet.getAnimalDataSet());
            Assert.AreEqual("1", response.animal.animalId);

        }

        [Test]
        public void GetAllAnimalsTest()
        {
            AnimalService service = new AnimalService();
            animal.Setup(t => t.RetrieveAllAnimals()).Returns(dataSet.getAnimalListDataSet());
            AnimalResponse response = service.GetAllAnimals();
            Assert.IsTrue(response.animalList.Count > 0);

        }


        [Test]
        public void DeleteAnimalTest()
        {
            AnimalService service = new AnimalService();
            animal.Setup(t => t.DeleteAnimal("1")).Returns(dataSet.getAnimalDataSet());
            AnimalResponse response = service.DeleteAnimal("1");
            Assert.IsTrue(response.animal.animalId == 1);
        }

        [Test]
        public void UpdateAnimalTest()
        {
            AnimalService service = new AnimalService();
            animal.Setup(t => t.UpdateAnimal(dataSet.getAnimalDataSet())).Returns(dataSet.getAnimalDataSet());
            AnimalResponse response = service.UpdateAnimal(dataSet.getAnimalDataSet());
            Assert.IsTrue(response.animal.animalId == 1);
        }
    }
}

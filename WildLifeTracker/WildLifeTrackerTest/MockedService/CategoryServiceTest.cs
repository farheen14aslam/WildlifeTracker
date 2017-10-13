using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildLifeTracker;
using WildLifeTracker.Repository;
using WildLifeTracker.Response;
using WildLifeTrackerTest.MockedModels;

namespace WildLifeTrackerTest
{


    [TestFixture]
    public class CategoryServiceTest
    {

        Mock<CategoryRepo> category = new Mock<CategoryRepo>();
        MockedDataSet dataSet = new MockedDataSet();
        [Test]
        public void TestAddCategoryService()
        {
            CategoryService service = new CategoryService();
            category.Setup(t => t.CreateNewCategory(dataSet.getCategoryDataSet())).Returns(dataSet.getCategoryDataSet());
            CategoryResponse response = service.AddCategory(dataSet.getCategoryDataSet());
            Assert.AreEqual("1", response.category.categoryId);

        }

        [Test]
        public void GetAllCategoriesTest()
        {
            CategoryService service = new CategoryService();
            category.Setup(t => t.RetrieveAllCategories()).Returns(dataSet.getCategoryListDataSet());
            CategoryResponse response = service.GetCategories();
            Assert.IsTrue(response.categoryList.Count>0);

        }

        [Test]
        public void GetEachCategoryTest()
        {
            CategoryService service = new CategoryService();
            category.Setup(t => t.RetrieveCategory("1")).Returns(dataSet.getCategoryDataSet());
            CategoryResponse response = service.GetCategory("1");
            Assert.IsTrue(response.category.categoryId == 1);
        }

        [Test]
        public void DeleteCategoryTest()
        {
            CategoryService service = new CategoryService();
            category.Setup(t => t.DeleteCategory("1")).Returns(dataSet.getCategoryDataSet());
            CategoryResponse response = service.DeleteCategory("1");
            Assert.IsTrue(response.category.categoryId == 1);
        }

        [Test]
        public void UpdateCategoryTest()
        {
            CategoryService service = new CategoryService();
            category.Setup(t => t.UpdateCategory( dataSet.getCategoryDataSet())).Returns(dataSet.getCategoryDataSet());
            CategoryResponse response = service.UpdateCategory(dataSet.getCategoryDataSet());
            Assert.IsTrue(response.category.categoryId == 1);
        }
    }
}

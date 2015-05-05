using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseHotelv2.Controllers;
using HouseHotelv2.Infrastructure;


namespace HouseHotelWebApiTest
{
    [TestClass]
    public class TestPropertiesController
    {
    
         private happyhousesv4Entities db = new happyhousesv4Entities();
        [TestMethod]
        public void GetAllProperties_ShouldReturnAllProperties()
        {
            var controller = new PropertiesController();  //Arrange

            var result = controller.GetAllProperties();  //Act
            var response = result as OkNegotiatedContentResult<IEnumerable<Property>>;  //Assert
            Assert.IsNotNull(response);

            //  var properties = response.Content;
            //  Assert.AreEqual(70, properties.Count());
 
        {
            
        }
        }
    }
}

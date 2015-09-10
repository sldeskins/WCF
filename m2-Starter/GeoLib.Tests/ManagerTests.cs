using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeoLib.Data;
using GeoLib.Services;
using GeoLib.Contracts;

namespace Geo.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void test_zip_code_retrieval ()
        {
            Mock<IZipCodeRepository> mockZipCodeRepository = new Mock<IZipCodeRepository>();
            ZipCode zipCode = new ZipCode()
            {
                City = "Lincoln Park",
                State = new State() { Abbreviation = "NJ" },
                Zip = "07035"
            };

            mockZipCodeRepository.Setup(obj => obj.GetByZip("07035")).Returns(zipCode);

            //--
            IGeoService geoService = new GeoManager(mockZipCodeRepository.Object);
            ZipCodeData data = geoService.GetZipInfo("07035");

            Assert.IsTrue(data.City == "Lincoln Park");
            Assert.IsTrue(data.State == "NJ");
        }
    }
}

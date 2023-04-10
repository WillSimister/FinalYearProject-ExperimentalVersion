using BirdSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim_Tests
{
    [TestClass]
    public class Country_Tests
    {
        public Country country = new Country("country", "CA");
        [TestMethod]
        public void Country_SetClosestCountries_SetCorrectly()
        {
            //Arrange
            string north = "north";
            string south = "south";
            string west = "west";
            string east = "east";

            //Act
            country.setClosestCountries(north, east, south, west);

            //Assert
            //That get Closest northern is equal to value of 'north'
            Assert.AreEqual(country.getClosestNorthern(), north);
            Assert.AreEqual(country.getClosestSouthern(), south);
            Assert.AreEqual(country.getClosestEastern(), east);
            Assert.AreEqual(country.getClosestWestern(), west);
        }

        [TestMethod]
        public void Country_SetClimateData_SetsCorrectly()
        {
            //Arrange
            Dictionary<int, double> climateData = new Dictionary<int, double>();
            //Act
            country.setClimateData(climateData);
            //Assert
            Assert.AreEqual(country.getClimateData(), climateData);
        }
    }
}

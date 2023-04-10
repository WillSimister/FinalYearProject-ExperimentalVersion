using BirdSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim_Tests
{
    [TestClass]
    public class SimulationController_Tests
    {
        SimulationController simulationController = new SimulationController(true);
        [TestMethod]
        public void SimulationController_SetAgentRule_SetsRuleToCorrectAgent()
        {
            //Arrange
            LatitudinalAgent agent = new LatitudinalAgent();
            Rule rule = new Rule();
            //Act
            simulationController.addAgentToAgentsList(agent);
            simulationController.setAgentRule(0, rule);
            //Assert
            Rule agentsRule = simulationController.getAgentsList()[0].getRules()[0];
            Assert.AreEqual(rule, agentsRule);
        }

        [TestMethod]
        public void SimulationController_GetCountryFromCountryCode_GetsCorrectCountry()
        {
            //Arrange
            string ExpectedName = "Mexico";
            string CountryCode_Mexico = "MX";
            //Act
            Country countryFromMX = simulationController.getCountryFromCountryCode(CountryCode_Mexico);
            //Assert
            Assert.AreEqual(ExpectedName, countryFromMX.getName());
        }

        [TestMethod]
        public void SimulationController_GetCountryFromCountryCode_CodeDoesNotExist_ReturnsNull()
        {
            //Arrange
            Country nullCountry = null;
            //Act
            Country countryFromCode = simulationController.getCountryFromCountryCode("XX");
            //Assert
            Assert.IsNull(countryFromCode);
            Assert.AreEqual(nullCountry, countryFromCode);
        }
    }
}

using BirdSim;

namespace BirdSim_Tests
{
    [TestClass]
    public class LatitudinalAgent_Tests
    {
        public LatitudinalAgent agent = new LatitudinalAgent();
        public Rule rule = new BirdSim.Rule(string.Empty, BirdSim.ruleTypeEnum.Month, false, false, false, false, false, 0, BirdSim.ActionEnum.migrateSouth);
        public Country country = new Country("country", "CA");
        [TestMethod]
        public void addRule_AddsRuleToRuleList()
        {
            //Arrange
            //Act
            agent.addRule(rule);
            //Assert
            Assert.That.Equals(agent.getRules().Contains(rule));
        }

        [TestMethod]
        public void setCurrentLocation_SetsCurrentLocation()
        {
            //Act
            agent.setCurrentLocation(country);
            //Assert
            Assert.AreEqual(country, agent.getCurrentLocation());
        }
    }
}
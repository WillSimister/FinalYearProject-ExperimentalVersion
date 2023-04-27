using BirdSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim_Tests
{
    [TestClass]
    public class Rule_Tests
    {
        [TestMethod]
        public void isRuleSafe_safeRulePassed_ReturnsTrue()
        {
            //Arrange
            Rule rule = new Rule("name", ruleTypeEnum.Month, true, false, false, false, false, 3, ActionEnum.migrateSouth);
            //Act
            bool safe = rule.isRuleSafe();
            //Assert
            Assert.IsTrue(safe);
        }

        [TestMethod]
        public void isRuleSafe_unsafeRulePassed_ReturnsFalse()
        {
            //Arrange
            Rule rule = new Rule("name", ruleTypeEnum.Month, true, true, false, false, false, 3, ActionEnum.migrateSouth);
            //Act
            bool safe = rule.isRuleSafe();
            //Assert
            Assert.IsFalse(safe);
        }
    }
}

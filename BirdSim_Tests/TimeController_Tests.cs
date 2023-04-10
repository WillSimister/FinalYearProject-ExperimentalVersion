using BirdSim;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim_Tests
{
    [TestClass]
    public class TimeController_Tests
    {
        [TestMethod]
        public void TimeController_ConstructorSetsValues_SetsMonthYearCorrectly()
        {
            //Arrange
            int month = 1;
            int year = 1999;
            //Act
            TimeController timeController = new TimeController(month, year);
            //Assert
            Assert.AreEqual(month, timeController.getSimulationController().getMonth());
            Assert.AreEqual(year, timeController.getSimulationController().getYear());
        }

        [TestMethod]
        public void TimeController_ProgressTime_MonthNOTTwelve_MonthIncresesByOne()
        {
            //Arrange
            bool runOneYear = true;
            TimeController timeController = new TimeController(runOneYear);

            int startingMonth = timeController.getSimulationController().getMonth();

            //Act 
            timeController.progressTime();
            int newMonth = timeController.getSimulationController().getMonth();

            //Assert
            Assert.AreEqual(1, startingMonth);
            Assert.AreEqual(2, newMonth);
        }

        [TestMethod]
        public void TimeController_ProgressTime_MonthEqualsTwelve_RunOneYearIsTrue_MonthSetToOne_RunOneYearSetToFalse()
        {
            //Arrange
            bool runOneYear = true;
            TimeController timeController = new TimeController(runOneYear);
            timeController.getSimulationController().setMonth(12);

            //Act
            timeController.progressTime();

            //Assert
            Assert.IsFalse(timeController.getOneYear());
            Assert.AreEqual(1, timeController.getSimulationController().getMonth());
        }

        [TestMethod]
        public void getTimeAsString_returnsTimeAsString()
        {
            //Arrange
            TimeController timeController = new TimeController();
            timeController.getSimulationController().setYear(1);
            timeController.getSimulationController().setMonth(1);

            //Act
            //This should be 1/1
            string TimeAsString = timeController.getTimeAsString();

            //Assert
            Assert.AreEqual("1/1", TimeAsString);

        }
    }
}

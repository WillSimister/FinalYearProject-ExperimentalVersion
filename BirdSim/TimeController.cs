using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class TimeController
    {
        private SimulationTime simulationTime;

        public TimeController(int month = 0, int year = 0)
        {
            if(month == 0 || year == 0)
            {
                simulationTime = new SimulationTime();
            }
            else
            {
                simulationTime = new SimulationTime(month, year);  
            }
        }

        public string getTimeAsString()
        {
           return simulationTime.getCurrentTime();
        }

        public void progressTime()
        {
            if(simulationTime.getMonth() != 12)
            {
                simulationTime.setMonth(simulationTime.getMonth() + 1);
            }
            else
            {
                simulationTime.setMonth(1);
                simulationTime.setYear(simulationTime.getYear() + 1);
            }
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    public class TimeController
    {
        private SimulationTime simulationTime;

        private bool runOneYear;

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

        public TimeController (bool _runOneYear)
        {
            runOneYear = _runOneYear;
            simulationTime = new SimulationTime(1, 0001);
        }

        public string getTimeAsString()
        {
           return simulationTime.getCurrentTime();
        }

        public SimulationTime getSimulationController()
        {
            return simulationTime;
        }

        public void progressTime()
        {
            if(simulationTime.getMonth() != 12)
            {
                simulationTime.setMonth(simulationTime.getMonth() + 1);
            }
            else
            {
                if(runOneYear == true)
                {
                    //Year is finished
                    runOneYear = false;
                    simulationTime.setMonth(1);
                    return;
                }
                simulationTime.setMonth(1);
                simulationTime.setYear(simulationTime.getYear() + 1);
            }
        }

        public bool getOneYear()
        {
            return runOneYear;
        }

        
    }
}

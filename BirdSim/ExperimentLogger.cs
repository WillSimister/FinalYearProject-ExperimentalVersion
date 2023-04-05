using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class ExperimentLogger
    {
        private List<string> log = new List<string>();

        public ExperimentLogger() 
        { }

        public void addLog(string logToLog)
        {
            log.Add(logToLog);
        }

        public void createLogFile(string experimentName, string experimentDescription)
        {
            ///Create text file with the log
        }

    }
}

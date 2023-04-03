using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Experiment
    {
        private SimulationInstance environment;
        private Agent agent;

        private string experimentName;
        private string? experimentDescription;
        private string experimentVersion;

        private string? experimentVersionDescription;
        private string results;

        public Experiment(SimulationInstance instance, Agent _agent, string expName, string expDesc, string expVer, string expVerDesc)
        {
            environment = instance;
            agent = _agent;
            experimentName = expName;
            experimentDescription = expDesc;
            experimentVersion = expVer;
            experimentVersionDescription = expVerDesc;
        }


        public void runExperiment()
        { }
        

    }
}

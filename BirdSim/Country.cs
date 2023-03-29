using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Country
    {
        private string name;
        private string countryCode;

        public Country(string name,string countryCode)
        {
            Climate climate = new Climate();
            simulationProperties.Add(climate);
            this.name = name;
            this.countryCode = countryCode;
        }

        List<SimulationProperty> simulationProperties = new List<SimulationProperty>();
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    public class SimulationInstance
    {
        private List<Country> countries;
        private string instanceName;

        public SimulationInstance(List<Country> countries, string instanceName)
        {
            this.countries = countries;
            this.instanceName = instanceName;
        }

        public List<Country> Countries { get { return countries; } }

        public string InstanceName { get { return instanceName;} }

        public void SetCountries(List<Country> newCountries)
        {
            this.countries = newCountries;
        }

    }
}

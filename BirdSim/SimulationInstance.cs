using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class SimulationInstance
    {
        private List<Country> countries;
                 
        public SimulationInstance(List<Country> countries)
        {
            this.countries = countries;
        }

        public List<Country> Countries { get { return countries; } }

        public void SetCountries(List<Country> newCountries)
        {
            this.countries = newCountries;
        }

    }
}

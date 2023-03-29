using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class SimulationInstance
    {
        private List<Country> countries = new List<Country>();

        public SimulationInstance(List<Country> _countries)
        {
            countries = _countries;
        }
    }
}

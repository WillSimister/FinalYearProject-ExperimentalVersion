using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    // Refactor so that there is a base class of agent
    internal class LatitudinalAgent
    {
        private string speciesName;
        private int NormalSouthernMigrationMonth;
        private int NormalNorthernMigrationMonth;
        private Country normalNorthernCountry;
        private Country normalSouthernCountry;

        public LatitudinalAgent(string name, int SouthernMonth, int NorthernMonth, Country NorthernCountry, Country SouthernCountry) 
        {
            speciesName = name;
            NormalSouthernMigrationMonth = SouthernMonth;
            NormalNorthernMigrationMonth = NorthernMonth;
            normalNorthernCountry = NorthernCountry;
            normalSouthernCountry = SouthernCountry;
        }

        public string getName()
        {
            return speciesName;
        }

        public int getNormalSouthernMigrationMonth()
        {
            return NormalSouthernMigrationMonth;
        }

        public int getNormalNorthernMigrationMonth()
        {
            return NormalNorthernMigrationMonth;
        }

        public Country getNormalNorthernCountry()
        {
            return normalNorthernCountry;
        }

        public Country getNormalSouthernCountry()
        {
            return normalSouthernCountry;
        }
    }
}

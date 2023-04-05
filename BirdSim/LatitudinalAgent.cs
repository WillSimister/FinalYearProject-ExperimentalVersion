using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    // Refactor so that there is a base class of agent
    internal class LatitudinalAgent : Agent
    {
        private string? speciesName;
        private Country? currentLocation;
        private int NormalSouthernMigrationMonth;
        private int NormalNorthernMigrationMonth;
        private Country? normalNorthernCountry;
        private Country? normalSouthernCountry;
        private List<Rule> rules = new List<Rule>();

        public LatitudinalAgent(string name, int SouthernMonth, int NorthernMonth, Country NorthernCountry, Country SouthernCountry, Country currentLocation) 
        {
            speciesName = name;
            NormalSouthernMigrationMonth = SouthernMonth;
            NormalNorthernMigrationMonth = NorthernMonth;
            normalNorthernCountry = NorthernCountry;
            normalSouthernCountry = SouthernCountry;
            this.currentLocation = currentLocation;
        }

        public LatitudinalAgent() { }

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

        public void addRule(Rule rule)
        {
            rules.Add(rule);
        }

        public List<Rule> getRules()
        {
            return rules;
        }

        public void setCurrentLocation(Country currentCountry)
        {
            currentLocation = currentCountry;
        }
    }
}

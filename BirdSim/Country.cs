﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Country
    {
        private string name;
        private string countryCode;
        private string ClosestNorthernCountryCode;
        private string ClosestEasternCountryCode;
        private string ClosestSouthernCountryCode;
        private string ClosestWesternCountryCode;

        private Dictionary<int, double> climateData;



        public Country(string name,string countryCode)
        {
            Climate climate = new Climate();
            simulationProperties.Add(climate);
            this.name = name;
            this.countryCode = countryCode;
        }

        public string getName()
        {
            return name;
        }

        public string getCode()
        {
            return countryCode;
        }

        public string getClosestNorthern()
        {
            return ClosestNorthernCountryCode;
        }

        public string getClosestEastern()
        {
            return ClosestEasternCountryCode;
        }

        public string getClosestSouthern()
        {
            return ClosestSouthernCountryCode;
        }

        public string getClosestWestern()
        {
            return ClosestWesternCountryCode;
        }

        public void setClosestCountries(string north, string east, string south, string west)
        {
            ClosestNorthernCountryCode = north;
            ClosestEasternCountryCode = east;
            ClosestSouthernCountryCode = south;
            ClosestWesternCountryCode = west;
        }

        public Dictionary<int, double> getClimateData ()
        {
            return climateData;
        }

        public void setClimateData(Dictionary<int, double> _climateData)
        {
            climateData = _climateData;
        }


        List<SimulationProperty> simulationProperties = new List<SimulationProperty>();
        
    }
}

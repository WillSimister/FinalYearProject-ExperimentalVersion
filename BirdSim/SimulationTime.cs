using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    public class SimulationTime
    {
        private int month = 1;
        private int year = 1965;

        public SimulationTime()
        {
            //Default constructor do nothing
        }

        public SimulationTime(int _month, int _year)
        {
            month = _month;
            year = _year;
        }

        public int getMonth()
        {
            return month;
        }

        public int getYear()
        {
            return year;
        }

        public void setMonth(int value)
        {
            month = value;
        }

        public void setYear(int value)
        {
            year = value;
        }

        public string getCurrentTime()
        {
            return month + "/" + year;
        }
    }
}

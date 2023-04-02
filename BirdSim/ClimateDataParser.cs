using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class ClimateDataParser
    {
        Dictionary<int, double> Plover_Arctic_BreedingGround = new Dictionary<int, double>()
        {
            {1, -22},
            {2, -23},
            {3, -18},
            {4, -9},
            {5, -1},
            {6, 7},
            {7, 12},
            {8, 10},
            {9, 5},
            {10, -1},
            {11, -8},
            {12, -17}
        };

        //Key = Month, Value = Temp in C
        Dictionary<int, double> Plover_NonBreeding_Argentina = new Dictionary<int, double>() 
        {
            {1, 28},
            {2, 27},
            {3, 25},
            {4, 21},
            {5, 18},
            {6, 15},
            {7, 14},
            {8, 16},
            {9, 18},
            {10, 21},
            {11, 24},
            {12, 27}
        };

        public Dictionary<int, double> getNorthernPlover()
        {
            return Plover_Arctic_BreedingGround;
        }

        public Dictionary<int, double> getSouthernPlover()
        {
            return Plover_NonBreeding_Argentina;
        }
        
      
}
}

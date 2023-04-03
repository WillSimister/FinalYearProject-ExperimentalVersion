using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Rule
    {
        string name;
        SimulationProperty property;
        bool greaterThan = false;
        bool lessThan = false;
        bool equalTo = false;
        bool and = false;
        bool or = false;
        int ruleParameter;
    }
}

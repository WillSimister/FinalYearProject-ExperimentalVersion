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
        ruleTypeEnum property;
        ActionEnum action;
        bool greaterThan = false;
        bool lessThan = false;
        bool equalTo = false;
        bool and = false;
        bool or = false;
        int ruleParameter;

        public Rule(string name, ruleTypeEnum property, bool greaterThan, bool lessThan, bool equalTo, bool and, bool or, int ruleParameter)
        {
            this.name = name;
            this.property = property;
            this.greaterThan = greaterThan;
            this.lessThan = lessThan;
            this.equalTo = equalTo;
            this.and = and;
            this.or = or;
            this.ruleParameter = ruleParameter;
            this.property = property;
        }

        public ruleTypeEnum getRuleType()
        {
            return property;
        }

        public ActionEnum getAction() { return action; }

        public string getActionAsString()
        {
            return action.ToString();
        }

        public string getRuleTypeAsString()
        {
            return property.ToString();
        }

        public ruleTypeEnum GetRuleType()
        {
            return property;
        }

        public int getRuleParameter()
        {
            return ruleParameter;
        }

        public bool getGreaterThan() { return greaterThan; }

        public bool getLessThan() { return lessThan;} 
        public bool getEqualTo() { return equalTo;}

        public string getRuleName() { return name; }
    }
}

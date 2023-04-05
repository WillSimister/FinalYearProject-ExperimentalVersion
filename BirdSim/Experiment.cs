using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Experiment
    {
        private SimulationController simulationController;
        private SimulationInstance environment;
        private Agent agent;

        private string experimentName;
        private string? experimentDescription;
        private string experimentVersion;

        private string? experimentVersionDescription;
        private string results;

        public Experiment(SimulationInstance instance, Agent _agent, string expName, string expDesc, SimulationController controller)
        {
            environment = instance;
            agent = _agent;
            experimentName = expName;
            experimentDescription = expDesc;
            simulationController = controller;
        }


        public void runExperiment()
        {
            LatitudinalAgent latAgent;
            if(agent.GetType() == typeof(LatitudinalAgent))
            {
                latAgent = (LatitudinalAgent)agent;
            }
            else
            {
                latAgent = new LatitudinalAgent();
            }

            //So we get a time controller - set month to 0;
            TimeController timeController = new TimeController();
            //Check is it Agents normal northern migration month
            if(latAgent != null)
            {
                bool hasMigrated = false;
                foreach (Rule rule in latAgent.getRules())
                {
                    if(rule.getRuleType() == ruleTypeEnum.Month)
                    {
                        checkMonthRules(ref hasMigrated, ref latAgent, rule, timeController);
                    }
                    if(rule.getRuleType() == ruleTypeEnum.ClimateTemp)
                    {
                        checkClimateTempRule(ref hasMigrated, ref latAgent, rule, timeController);
                    }
                }
            }
            //Check if any rules are being hit
            
        }


        private void checkMonthRules(ref bool hasMigrated, ref LatitudinalAgent latAgent, Rule rule, TimeController timeController)
        {
            if (rule.getGreaterThan() == true)
            {
                if (timeController.getSimulationController().getMonth() > rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
            if (rule.getLessThan() == true)
            {
                if (timeController.getSimulationController().getMonth() < rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
            if (rule.getEqualTo() == true)
            {
                if (timeController.getSimulationController().getMonth() == rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
        }

        private void checkClimateTempRule(ref bool hasMigrated, ref LatitudinalAgent latAgent, Rule rule, TimeController timeController)
        {
            if (rule.getGreaterThan() == true)
            {
                if (environment.Countries.FirstOrDefault()
                    .getClimateData()
                    .GetValueOrDefault(timeController.getSimulationController().getMonth()) > rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
            if (rule.getLessThan() == true)
            {
                if (environment.Countries.FirstOrDefault()
                    .getClimateData()
                    .GetValueOrDefault(timeController.getSimulationController().getMonth()) > rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
            if (rule.getEqualTo() == true)
            {
                if (environment.Countries.FirstOrDefault()
                    .getClimateData()
                    .GetValueOrDefault(timeController.getSimulationController().getMonth()) > rule.getRuleParameter())
                {
                    makeDecision(ref latAgent, rule, ref hasMigrated);
                }
            }
        }


        private void makeDecision(ref LatitudinalAgent latAgent, Rule rule, ref bool hasMigrated)
        {
            if (rule.getAction() == ActionEnum.migrateNorth)
            {
                if (hasMigrated)
                {
                    Country nextClosestNorthernCountry = simulationController.getCountryFromCountryCode(latAgent.getNormalNorthernCountry().getClosestNorthern());
                    latAgent.setCurrentLocation(nextClosestNorthernCountry);
                    //Log Migration
                }
                else
                {
                    latAgent.setCurrentLocation(latAgent.getNormalNorthernCountry());
                    //Log Migration
                }
            }
            else if (rule.getAction() == ActionEnum.migrateSouth)
            {
                if (hasMigrated)
                {
                    Country nextClosestSouthernCountry = simulationController.getCountryFromCountryCode(latAgent.getNormalSouthernCountry().getClosestSouthern());
                    latAgent.setCurrentLocation(nextClosestSouthernCountry);
                }
                else
                {
                    //log Migration
                    latAgent.setCurrentLocation(latAgent.getNormalSouthernCountry());
                }
            }
        }

        //private bool isWithinMinMaxForLocation(bool northSouth, LatitudinalAgent agent) //True = north, False = south
        //{
        //    if(northSouth == true)
        //    {
        //        environment.
        //    }
        //}


        public string getName()
        {
            return experimentName;
        }
        


    }
}

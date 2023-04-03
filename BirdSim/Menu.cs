using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BirdSim
{
    internal class Menu
    {
        private SimulationController controller;
        public Menu(SimulationController simulationController) 
        {
            controller = simulationController;
        }

        public void produceMainMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("---------------------Bird Migration Simulator-------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("------AGENT OPTIONS--------ENVIRONMENT OPTIONS-----------EXPERIMENTS--");
            Console.WriteLine("------1.Create Agent-------a.Create Environment-----------------------");
            Console.WriteLine("------2.View/Edit Agents---b.View/Edit Environment(s)-----------------");
            Console.WriteLine("------3.Add Rule to Agent---------------------------------------------");

            string input = getInput();
            processInput(input);
        }

        public string getInput()
        {
            string input;
            Console.Write(">>> ");
            input = Console.ReadLine();
            return input;
        }

        public void processInput(string input)
        {
            switch (input)
            {
                case "1":
                    {
                        showCreateAgentMenu();
                        break;
                    }
                case "2":
                    {
                        showViewEditAgentMenu();
                        break;
                    }
                case "3":
                    {
                        addRuleToAgentMenu();
                        break;
                    }
                case "a":
                    {
                        ShowCreateEnvironmentMenu();
                        break;
                    }
                case "b":
                    {
                        showEnvironmentsMenu();
                        break;
                    }
                default:
                    {
                        produceMainMenu();
                        break;
                    }
            }
        }

        public void showViewEditAgentMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------View/Edit Agents----------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (LatitudinalAgent latitudinalAgent in controller.getAgentsList())
            {
                Console.WriteLine($"---Name: {latitudinalAgent.getName()}------------------------------------");
            }
            Console.WriteLine("--Q = Back------------------------------------------------------------");

            getInput();
        }

        public void showCreateAgentMenu()
        {
            string name;
            int normalNorthernMonth;
            int normalSouthernMonth;
            Country normalNorthernCountry;
            Country normalSouthernCountry;
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Create Agent--------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("--Input Species Name >>> ");
            name = Console.ReadLine();

            Console.Write("\n--Input normal Month that the species migrate north (As an integer) >>>");
            normalNorthernMonth = int.Parse(Console.ReadLine());

            Console.Write("\n--Input normal Month that the species migrate south (As an integer) >>>");
            normalSouthernMonth = int.Parse(Console.ReadLine());

            Console.Write("\n--Input normal Northern Country - Enter ISO Country Code >>> ");
            normalNorthernCountry = controller.getCountryFromCountryCode(Console.ReadLine());

            Console.Write("\n--Input normal Southern Country - Enter ISO Country Code >>> ");
            normalSouthernCountry = controller.getCountryFromCountryCode(Console.ReadLine());

            LatitudinalAgent agent = new LatitudinalAgent(name, normalSouthernMonth, normalNorthernMonth, normalNorthernCountry, normalSouthernCountry);
            controller.addAgentToAgentsList(agent);

            produceMainMenu();
        }

        public void ShowCreateEnvironmentMenu()
        {
            string instanceName;
            Country northernMostCountry;
            Country southernMostCountry;
            string northNorthCountry;
            string eastNorthCountry;
            string southNorthCountry;
            string westNorthCountry;
            string northSouthCountry;
            string eastSouthCountry;
            string southSouthCountry;
            string westSouthCountry;
            ClimateDataParser climateData = new ClimateDataParser();
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Create Environment--------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----Add two countries - The northern most and southern most country---");
            Console.WriteLine("------and the southern most country of a birds migration pattern------");
            Console.Write("--Instance name >>> ");
            instanceName = Console.ReadLine();
            Console.Write("\n--Northern Most (Using ISO 2 Character Code) >>> ");
            northernMostCountry = controller.getCountryFromCountryCode(Console.ReadLine());
            Console.Write("\n--Southern Most (Using ISO 2 Character Code) >>> ");
            southernMostCountry = controller.getCountryFromCountryCode(Console.ReadLine());
            Console.Write("\n--Add northern most data >>> ");
            northernMostCountry.setClimateData(climateData.getNorthernPlover());
            Console.Write("Done");
            Console.Write("\n--Add southern most data >>> ");
            southernMostCountry.setClimateData(climateData.getSouthernPlover());
            Console.Write("Done");
            Console.WriteLine("Using the ISO 2 Character code - what is the next country north of the Northern Country in this instance >>>");
            northNorthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country east of the Northern Country in this instance >>>");
            eastNorthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country south of the Northern Country in this instance >>>");
            southNorthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country west of the Northern Country in this instance >>>");
            westNorthCountry = Console.ReadLine();

            Console.WriteLine("Using the ISO 2 Character code - what is the next country north of the Southern Country in this instance >>>");
            northSouthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country east of the Southern Country in this instance >>>");
            eastSouthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country south of the Southern Country in this instance >>>");
            southSouthCountry = Console.ReadLine();
            Console.WriteLine("Using the ISO 2 Character code - what is the next country west of the Southern Country in this instance >>>");
            westSouthCountry = Console.ReadLine();

            northernMostCountry.setClosestCountries(northNorthCountry, eastNorthCountry, southNorthCountry, westNorthCountry);
            southernMostCountry.setClosestCountries(northSouthCountry, eastSouthCountry, southSouthCountry, westSouthCountry);

            List<Country> environment = new List<Country>();
            environment.Add(northernMostCountry);
            environment.Add(southernMostCountry);

            SimulationInstance simulationInstance = new SimulationInstance(environment, instanceName);
            controller.addEnvironment(simulationInstance);

            produceMainMenu();
        }

        public void showEnvironmentsMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("-----------------------View/Edit Environment(s)-----------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (SimulationInstance instance in controller.getEnvironments())
            {
                Console.WriteLine($"--Name: {instance.InstanceName}------------------------------------");
            }
            Console.WriteLine("--Q = Back------------------------------------------------------------");

        }

        public void addRuleToAgentMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Add Rule to Agent---------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--- Select an Agent to add a rule to... ------------------------------");
            foreach (LatitudinalAgent latitudinalAgent in controller.getAgentsList())
            {
                Console.WriteLine($"---({controller.getAgentsList().IndexOf(latitudinalAgent)})Name: {latitudinalAgent.getName()}------------------------------------");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("--- Select agent >>> ");
            string agentInput = Console.ReadLine();


            Console.Clear();
            string ruleName;
            SimulationProperty? simulationProperty;
            SimulationProperty? simulationProperty1;
            SimulationProperty? simulationProperty2;
            int propertyValue;
            int property2Value;
            int property3Value;
            bool greaterThan = false;
            bool lessThan = false;
            bool equalTo = false;
            bool and = false;
            bool or = false;
            bool greaterThan2 = false;
            bool lessThan2 = false;
            bool equalTo2 = false;
            bool and2 = false;
            bool or2 = false;
            bool greaterThan3 = false;
            bool lessThan3 = false;
            bool equalTo3 = false;
            bool and3 = false;
            bool or3 = false;
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Add Rule to Agent---------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("-----------------------------Create Rule------------------------------");
            Console.Write("--- Name the rule >>> ");
            ruleName = Console.ReadLine();
            Console.Write("\n--- Which Simulation Property is this targetting? >>> ");
            simulationProperty = new Climate();
            Console.Write("--- The Simulation Property value should be...");
            Console.Write("\n--- 1. Greater than");
            Console.Write("\n--- 2. Less than");
            Console.Write("\n--- 3. Equal to");
            Console.Write("\n--- >>> ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {
                        greaterThan = true;
                        break;
                    }
                case "2":
                    {
                        lessThan = true;
                        break;
                    }
                case "3":
                    {
                        equalTo = true;
                        break;
                    }
            }
            Console.Write("\n what int should the property value be greater than, less to or equal to? >>> ");
            propertyValue = int.Parse(Console.ReadLine());
            Console.Write("\n--- Should the Simulation Property have any other indicators --- should there be a logical AND or a logical OR? (Y/N) >>> ");
            string yesNo = Console.ReadLine();

            if (yesNo.ToLower() == "y") 
            {
                if(andOr() == "AND")
                {
                    and = true;
                }
                else
                {
                    or = true;
                }
            }
            else
            {

            }
            Console.WriteLine("--Q = Back------------------------------------------------------------");
        }

        private string andOr()
        {
            Console.Write("\n--- type AND or OR >>>");
            return Console.ReadLine();

        }

        //private void addSimulationPropertyRule(int addAndorPlusVal)
        //{
            
        //    Console.Write("--- type AND or OR >>>");
        //    Console.Write("--- The Simulation Property value should be...");
        //    Console.Write("\n--- 1. Greater than");
        //    Console.Write("\n--- 2. Less than");
        //    Console.Write("\n--- 3. Equal to");
        //    Console.Write("\n--- >>> ");
        //    string input = Console.ReadLine();
        //    switch (input)
        //    {
        //        case "1":
        //            {
        //                greaterThan = true;
        //                break;
        //            }
        //        case "2":
        //            {
        //                lessThan = true;
        //                break;
        //            }
        //        case "3":
        //            {
        //                equalTo = true;
        //                break;
        //            }
        //    }
        //    Console.Write("\n what int should the property value be greater than, less to or equal to? >>> ");
        //    propertyValue = int.Parse(Console.ReadLine());
        //}
    }
}

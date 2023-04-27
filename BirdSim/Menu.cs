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
    public class Menu
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
            Console.WriteLine("------AGENT OPTIONS--------ENVIRONMENT OPTIONS--------EXPERIMENTS-----");
            Console.WriteLine("------1.Create Agent-------a.Create Environment-------4.New Experiment");
            Console.WriteLine("------2.View/Edit Agents---b.View/Edit Environment(s)-5.Run Experiments");
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
                case "4":
                    {
                        showCreateExperimentMenu();
                        break;
                    }
                case "5":
                    {
                        viewEditExperiments();
                        break;
                    }
                case "6":
                    {
                        controller.saveEnvironments();
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
                Console.WriteLine($"---ID:{controller.getAgentsList().IndexOf(latitudinalAgent)} Name: {latitudinalAgent.getName()}------------------------------------");
            }
            Console.WriteLine("--A = View an Agents Ruleset---------------------------------------------");
            Console.WriteLine("--Q = Back------------------------------------------------------------");
            Console.Write("-- >>> ");
            string firstInput = Console.ReadLine().ToLower();
            
            if(firstInput == "a")
            {
                Console.Write("Enter ID of agent you wish to see the ruleset for");
                Console.Write("\n-- >>> ");
                string secondInput = Console.ReadLine();

                if(int.TryParse(secondInput, out int i))
                {
                    if(i <= controller.getAgentsList().Count)
                    {
                        viewAgentsRules(controller.getAgentsList()[i]);
                    }
                }
            }

            string input = getInput();
            processInput(input);
        }

        private void viewAgentsRules(LatitudinalAgent latitudinalAgent)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------Agents Rules------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"--Rules for {latitudinalAgent.getName()} ----------------------------");
            foreach(Rule rule in latitudinalAgent.getRules())
            {
                string comparator;
                if(rule.getGreaterThan() == true)
                {
                    comparator = "greater than";
                }
                else if(rule.getLessThan() == true)
                {
                    comparator = "less than";
                }
                else
                {
                    comparator = "equal to";
                }
                Console.WriteLine($"-- Rule Name: {rule.getRuleName()}, Rule checks that: {rule.getRuleTypeAsString()}, is {comparator} the value: {rule.getRuleParameter()} if this rule is met the agent will - {rule.getActionAsString()}");
            }
        }

        public void showCreateAgentMenu()
        {
            string name;
            int normalNorthernMonth;
            int normalSouthernMonth;
            Country normalNorthernCountry;
            Country normalSouthernCountry;
            Country currentCountry;
            
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Create Agent--------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("--Input Species Name >>> ");
            name = Console.ReadLine();

            Console.Write("\n--Input normal Month that the species migrate north (As an integer) >>>");
            int.TryParse(Console.ReadLine(), out normalNorthernMonth);

            Console.Write("\n--Input normal Month that the species migrate south (As an integer) >>>");
            int.TryParse(Console.ReadLine(), out normalSouthernMonth);

            Console.Write("\n--Input normal Northern Country - Enter ISO Country Code >>> ");
            normalNorthernCountry = controller.getCountryFromCountryCode(Console.ReadLine());

            Console.Write("\n--Input normal Southern Country - Enter ISO Country Code >>> ");
            normalSouthernCountry = controller.getCountryFromCountryCode(Console.ReadLine());

            if (normalNorthernCountry == null|| normalSouthernCountry == null)
            {
                Console.WriteLine("One of your country codes does not exist - try again");
                Console.ReadKey();
                showCreateAgentMenu();
            }

            Console.Write("\n--Which country should this species be located in January? --------------");
            Console.Write($"\n-- 1. {normalNorthernCountry.getName()} --------------------------------");
            Console.Write($"\n-- 2. {normalSouthernCountry.getName()} --------------------------------");
            Console.Write("\n-- 1 or 2? >>> ");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        currentCountry = normalNorthernCountry;
                        break;
                    }
                case "2":
                    {
                        currentCountry = normalSouthernCountry;
                        break;
                    }
                default:
                    {
                        currentCountry = normalNorthernCountry;
                        break;
                    }
            }

            if(name == "" || normalSouthernMonth == 0 || normalNorthernCountry == null || normalNorthernMonth == null || currentCountry == null)
            {
                Console.WriteLine("Something wasn't inputted correctly - try again");
                Console.ReadKey();
                showCreateAgentMenu();
            }
            else
            {
                LatitudinalAgent agent = new LatitudinalAgent(name, normalSouthernMonth, normalNorthernMonth, normalNorthernCountry, normalSouthernCountry, currentCountry);
                controller.addAgentToAgentsList(agent);
                Console.WriteLine($"{name}: agent created");

                string input = getInput();
                processInput(input);

            }
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

            if(northernMostCountry == null || southernMostCountry == null)
            {
                Console.WriteLine("One of your country codes does not exist - try again");
                Console.ReadKey();
                ShowCreateEnvironmentMenu();
            }

            Console.Write("\n--Add northern most data >>> ");
            northernMostCountry.setClimateData(climateData.getNorthernPlover());
            Console.Write("Done");
            Console.Write("\n--Add southern most data >>> ");
            southernMostCountry.setClimateData(climateData.getSouthernPlover());
            Console.Write("Done");
            Console.Write("\nUsing the ISO 2 Character code - what is the next country north of the Northern Country in this instance >>>");
            northNorthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country east of the Northern Country in this instance >>>");
            eastNorthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country south of the Northern Country in this instance >>>");
            southNorthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country west of the Northern Country in this instance >>>");
            westNorthCountry = Console.ReadLine();

            Console.Write("\nUsing the ISO 2 Character code - what is the next country north of the Southern Country in this instance >>>");
            northSouthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country east of the Southern Country in this instance >>>");
            eastSouthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country south of the Southern Country in this instance >>>");
            southSouthCountry = Console.ReadLine();
            Console.Write("\nUsing the ISO 2 Character code - what is the next country west of the Southern Country in this instance >>>");
            westSouthCountry = Console.ReadLine();

            if (instanceName == "" || northNorthCountry == "" || northSouthCountry == "" || eastNorthCountry == "" || westNorthCountry == "" || southNorthCountry == "" || westSouthCountry == "" || eastNorthCountry == "")
            {
                Console.WriteLine("\nSomething wasn't inputted correctly - try again");
                ShowCreateEnvironmentMenu();
            }

            northernMostCountry.setClosestCountries(northNorthCountry, eastNorthCountry, southNorthCountry, westNorthCountry);
            southernMostCountry.setClosestCountries(northSouthCountry, eastSouthCountry, southSouthCountry, westSouthCountry);

            List<Country> environment = new List<Country>();
            environment.Add(northernMostCountry);
            environment.Add(southernMostCountry);

            SimulationInstance simulationInstance = new SimulationInstance(environment, instanceName);
            controller.addEnvironment(simulationInstance);

            string input = getInput();
            processInput(input);
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

            string input = getInput();
            processInput(input);
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
            ruleTypeEnum simulationProperty;
            ActionEnum simulationAction;
            SimulationProperty? simulationProperty2;
            int propertyValue;
            int property2Value;
            bool greaterThan = false;
            bool lessThan = false;
            bool equalTo = false;
            bool and = false;
            bool or = false;
            bool greaterThan2 = false;
            bool lessThan2 = false;
            bool equalTo2 = false;


            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Add Rule to Agent---------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("-----------------------------Create Rule------------------------------");
            Console.Write("--- Name the rule >>> ");
            ruleName = Console.ReadLine();
            Console.Write("\n--- Which Simulation Property is this targetting? ");
            Console.Write("\n--- 1. Month");
            Console.Write("\n--- 2. Temperature");
            Console.Write("\n--- >>> ");
            string simPropInput = Console.ReadLine();

            if (simPropInput == "")
            {
                Console.WriteLine("Sorry that wasn't quite right - try again");
                addRuleToAgentMenu();
            }

            switch (simPropInput)
            {
                case "1":
                    {
                        simulationProperty = ruleTypeEnum.Month;
                        break;
                    }
                case "2":
                    {
                        simulationProperty = ruleTypeEnum.ClimateTemp;
                        break;
                    }
                default:
                    {
                        simulationProperty = ruleTypeEnum.Month;
                        break;
                    }
            }

            Console.Write("--- The Simulation Property value should be...");
            Console.Write("\n--- 1. Greater than");
            Console.Write("\n--- 2. Less than");
            Console.Write("\n--- 3. Equal to");
            Console.Write("\n--- >>> ");
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.WriteLine("Sorry that wasn't quite right - try again");
                addRuleToAgentMenu();
            }
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
            Console.Write("\n what int value should the property value be greater than, less to or equal to? ");
            Console.Write("\n >>> ");
            
            propertyValue = int.Parse(Console.ReadLine());
            //Console.Write("\n--- Should the Simulation Property have any other indicators --- should there be a logical AND or a logical OR? (Y/N) >>> ");
            //string yesNo = Console.ReadLine();

            //if (yesNo.ToLower() == "y") 
            //{
            //    if(andOr() == "AND")
            //    {
            //        and = true;
            //    }
            //    else
            //    {
            //        or = true;
            //    }
            //}
            //else
            //{

            //}

            Console.Write("\n--- Which Simulation Action should occur? ");
            Console.Write("\n--- 1. Try Migrate to Breeding Location");
            Console.Write("\n--- 2. Try Migrate to Nesting Location");
            Console.Write("\n--- >>> ");
            string simActionInput = Console.ReadLine();

            if (simActionInput == "")
            {
                Console.WriteLine("Sorry that wasn't quite right - try again");
                addRuleToAgentMenu();
            }

            switch (simPropInput)
            {
                case "1":
                    {
                        simulationAction = ActionEnum.migrateNorth;
                        break;
                    }
                case "2":
                    {
                        simulationAction = ActionEnum.migrateSouth;
                        break;
                    }
                default:
                    {
                        simulationAction = ActionEnum.migrateNorth;
                        break;
                    }
            }


            if (ruleName == "" || simulationProperty == null)
            {
                Console.WriteLine("Sorry that wasn't quite right - try again");
                addRuleToAgentMenu();
            }

            Rule rule = new Rule(ruleName, simulationProperty, greaterThan, lessThan, equalTo, and, or, propertyValue, simulationAction);
            controller.setAgentRule(int.Parse(agentInput), rule);
            Console.WriteLine("--Q = Back------------------------------------------------------------");

            string newInp = getInput();
            processInput(newInp);
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

        public void showCreateExperimentMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Create Experiment---------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--- What should we name this experiment ------------------------------");
            string experimentName = Console.ReadLine();

            Console.WriteLine("--- Add a description for this experiment ----------------------------");
            string experimentDesc = Console.ReadLine();

            Console.WriteLine("--- Select an Agent --------------------------------------------------");
            foreach (LatitudinalAgent latitudinalAgent in controller.getAgentsList())
            {
                Console.WriteLine($"---({controller.getAgentsList().IndexOf(latitudinalAgent)})Name: {latitudinalAgent.getName()}------------------------------------");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("--- Select agent >>> ");
            string agentInput = Console.ReadLine();

            Console.WriteLine("--- Select an Environment --------------------------------------------------");
            foreach (SimulationInstance environmentInstance in controller.getEnvironments())
            {
                Console.WriteLine($"---({controller.getEnvironments().IndexOf(environmentInstance)})Name: {environmentInstance.InstanceName}------------------------------------");
            }
            Console.WriteLine("----------------------------------------------------------------------");
            Console.Write("--- Select Environment >>> ");
            string environment = Console.ReadLine();



            if (environment == "" || agentInput == "" || experimentDesc == "" || experimentName == "")
            {
                if (!int.TryParse(environment, out int res))
                {
                    if(!int.TryParse(agentInput, out int resA))
                    {
                        if(res > controller.getEnvironments().Count || resA > controller.getAgentsList().Count)
                        {
                            Console.WriteLine("Sorry something was entered incorrectly - try again");
                            showCreateExperimentMenu();
                        }
                        Console.WriteLine("Sorry something was entered incorrectly - try again");
                        showCreateExperimentMenu();
                    }
                    Console.WriteLine("Sorry something was entered incorrectly - try again");
                    showCreateExperimentMenu();
                }
                Console.WriteLine("Sorry something was entered incorrectly - try again");
                showCreateExperimentMenu();
            }

            Experiment newExperiment = new Experiment(controller.getEnvironments()[int.Parse(environment)], controller.getAgentsList()[int.Parse(agentInput)], experimentName, experimentDesc, controller);
            controller.addExperimentToList(newExperiment);

            string input = getInput();
            processInput(input);
        }

        public void viewEditExperiments()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("-------------------------View/Run Experiments-------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (Experiment experiment in controller.getExperiments())
            {
                Console.WriteLine($"---({controller.getExperiments().IndexOf(experiment)})Name: {experiment.getName()}------------------------------------");
            }
            Console.WriteLine("--A = Run Experiment--------------------------------------------------");
            Console.WriteLine("--Q = Back------------------------------------------------------------");
            Console.Write("--- >>> ");
            string firstInput = Console.ReadLine().ToLower();
            Console.WriteLine();
            if (firstInput == "a")
            {
                Console.WriteLine("Enter ID of experiment you wish to run");
                Console.Write("--- >>> ");
                string secondInput = Console.ReadLine();

                if (int.TryParse(secondInput, out int i))
                {
                    if (i <= controller.getExperiments().Count)
                    {
                        controller.getExperiments()[i].runExperiment();
                    }
                }
            }



            string input = getInput();
            processInput(input);
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("------1.Create Agent-------1.Create Environment-----------------------");
            Console.WriteLine("------2.View/Edit Agents---2.View/Edit Environment(s)-----------------");
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
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("--------------------------Create Agent--------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}

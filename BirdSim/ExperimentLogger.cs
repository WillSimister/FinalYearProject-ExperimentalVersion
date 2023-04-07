using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BirdSim
{
    internal class ExperimentLogger
    {
        private List<string> log = new List<string>();
        private Experiment exp;
        private string currentLogFile;

        public ExperimentLogger(Experiment experiment)
        {
            exp = experiment;
            createLogFile(experiment.getName());
        }

        public void addLog(string logToLog)
        {
            log.Add(logToLog);
        }

        public void createLogFile(string experimentName)
        {
            ///Create text file with the log
            string fileName = @$"C:\ExperimentLogs\{experimentName}.txt"; ;

            try
            {
                // Check if file already exists. If yes, change name.    
                if (File.Exists(fileName))
                {
                    char last = experimentName.LastOrDefault();
                    if(int.TryParse(last.ToString(), out int res))
                    {
                        string newExperimentName = experimentName + (last+1);
                        experimentName = newExperimentName;
                    }
                    else
                    {
                        experimentName = experimentName + 1;

                    }
                    fileName = @$"C:\ExperimentLogs\{experimentName}.txt";
                }
                currentLogFile = fileName;


                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("Experiment Handler");
                    fs.Write(author, 0, author.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

        public void addNewLineToLog(string textToAdd)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(currentLogFile, true, Encoding.Default);

                sw.WriteLine(textToAdd);

                //close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}

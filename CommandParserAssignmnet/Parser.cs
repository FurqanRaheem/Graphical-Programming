using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParserAssignmnet
{
    public class Parser: Command
    {
        private Dictionary<string, Action<string[]>> commandDictionary;

        public Parser()
        {
            commandDictionary = new Dictionary<string, Action<string[]>>(StringComparer.OrdinalIgnoreCase);

            commandDictionary["moveTo"] = MoveTo;
            commandDictionary["drawTo"] = DrawTo;
            commandDictionary["clear"] = Clear;
            commandDictionary["reset"] = Reset;
        }

        public void ParseProgram(string programText)
        {
            string[] lines = programText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                ParseLine(line);
            }
        }

        public void ParseLine(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length == 0)
            {
                Console.WriteLine("Invalid command. Please enter a valid command.");
                return;
            }

            string commandName = parts[0];
            if (commandDictionary.ContainsKey(commandName))
            {
                string[] parameters = new string[parts.Length - 1];
                Array.Copy(parts, 1, parameters, 0, parameters.Length);

                commandDictionary[commandName](parameters);
            }
            else
            {
                Console.WriteLine($"Command '{commandName}' not recognized. Type 'help' for a list of commands.");
            }
        }


        private void MoveTo(string[] parameters)
        {
            
        }

        private void DrawTo(string[] parameters)
        {
            
        }

        private void Clear(string[] parameters)
        {
           
        }

        private void Reset(string[] parameters)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandParserAssignmnet
{
    public class Parser
    {
        private Command command;
        private Dictionary<string, Action<string[]>> commandDictionary;

        public Parser(GraphicsHandler graphicsHandler)
        {
            this.command = new Command(graphicsHandler);

            // Create a dictionary of commands and their corresponding methods
            commandDictionary = new Dictionary<string, Action<string[]>>(StringComparer.OrdinalIgnoreCase);
            SetCommandDictionary();
        }

        /// <summary>
        /// Populates the command dictionary with the commands and their corresponding methods.
        /// </summary>
        private void SetCommandDictionary()
        {
            commandDictionary["moveTo"] = command.MoveTo;
            commandDictionary["drawTo"] = command.DrawTo;
            commandDictionary["clear"] = command.Clear;
            commandDictionary["reset"] = command.Reset;
            commandDictionary["pen"] = command.Pen;
            commandDictionary["fill"] = command.Fill;
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
                throw new ArgumentException("No command entered.");
            }

            string commandName = parts[0];
            if (commandDictionary.ContainsKey(commandName))
            {
                string[] parameters = parts.Length > 1 ? parts[1].Split(',') : Array.Empty<string>();
                commandDictionary[commandName](parameters);
            }
            else
            { 
                throw new ArgumentException($"Command '{commandName}' not recognized. Type 'help' for a list of commands.");
            }
        }
    }
}
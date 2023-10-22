using System;

namespace CommandParserAssignmnet
{
    public class Parser
    {
        private Form1? form1;
        private Command command;
        private Dictionary<string, Action<string[]>> commandDictionary;

        public Parser(GraphicsHandler graphicsHandler, Form1 form1)
        {
            this.command = new Command(graphicsHandler);
            this.form1 = form1;

            // Create a dictionary of commands and their corresponding methods
            commandDictionary = new Dictionary<string, Action<string[]>>(StringComparer.OrdinalIgnoreCase);
            SetCommandDictionary();
        }

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
            commandDictionary["circle"] = command.Circle;
            commandDictionary["rectangle"] = command.Rectangle;
            commandDictionary["square"] = command.Square;
            commandDictionary["triangle"] = command.Triangle;
            commandDictionary["help"] = command.Help;
        }

        /// <summary>
        /// Parses a program text by splitting it into individual lines and processing each line.
        /// </summary>
        /// <param name="programText">The text of the program to be parsed, consisting of one or more lines.</param>
        /// <remarks>
        /// This method takes the provided program text and splits it into individual lines based on carriage return and line feed characters. It then processes each line using the <see cref="ParseLine"/> method.
        /// </remarks>
        /// <param name="programText">The text of the program to be parsed.</param>
        public void ParseProgram(string programText)
        {
            string[] lines = programText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                ParseLine(line);
                
                // Add delay for "smooth" animations 
                Thread.Sleep(Globals.animationDelay);

                // Cringe, but it works
                // In an if block for testing purposes 
                if (form1 != null)
                {
                    form1.Refresh();
                }
            }
        }

        /// <summary>
        /// Parses a single line of input, identifies the command and its parameters, and executes the corresponding action.
        /// </summary>
        /// <remarks>
        /// This method takes a single line of input, splits it into individual parts using space as a delimiter, and identifies the command name.
        /// If the command name is recognized in the <see cref="commandDictionary"/> dictionary, the corresponding action is executed with any specified parameters.
        /// If the command is not recognized, an exception is thrown indicating the unrecognized command. The user can type 'help' to get a list of recognized commands.
        /// </remarks>
        /// <param name="input">The input line to be parsed, containing the command and its optional parameters.</param>
        /// <exception cref="ArgumentException">Thrown if no command is entered or if the command is not recognized.</exception>
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
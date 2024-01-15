using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace CommandParserAssignmnet
{
    public class Parser
    {
        private Form1? form1;
        private Command command;
        private Variables variables;
        private IfStatement ifStatement;
        private Dictionary<string, Action<string[]>> commandDictionary;
        private bool parseLine = true;
        private bool storingCommands = false;
        private bool storingMethod = false;
        private string storingMethodName = "";
        private Queue<string> tempMethodQueue = new Queue<string>();
        private int loopCount = 0;
        private Queue<string> blockQueue = new Queue<string>();
        private Dictionary<string, Queue<string>> methodsDictionary = new Dictionary<string, Queue<string>>();
        private Dictionary<string, int> methodParams = new Dictionary<string, int>();

        public Parser(GraphicsHandler graphicsHandler, Form1 form1)
        {
            this.command = new Command(graphicsHandler);
            this.variables = Variables.Instance;
            this.ifStatement = new IfStatement();
            this.form1 = form1;

            // Create a dictionary of commands and their corresponding methods
            commandDictionary = new Dictionary<string, Action<string[]>>(StringComparer.OrdinalIgnoreCase);
            SetCommandDictionary();
        }

        public Parser(GraphicsHandler graphicsHandler)
        {
            this.command = new Command(graphicsHandler);
            this.variables = Variables.Instance;
            this.ifStatement = new IfStatement();

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
            commandDictionary["run"] = Run;
        }

        /// <summary>
        /// Parses a program text by splitting it into individual lines and processing each line.
        /// </summary>
        /// <param name="programText">The text of the program to be parsed, consisting of one or more lines.</param>
        /// <remarks>
        /// This method takes the provided program text and splits it into individual lines based on carriage return and line feed characters. It then processes each line using the <see cref="ParseLine"/> method.
        /// </remarks>
        /// <param name="programText">The text of the program to be parsed.</param>
        public void ParseProgram(string programText, bool syntaxCheck = false)
        {
            if(syntaxCheck)
            {
                command.Active = false;
            }

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

            command.Active = true;
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
            ThrowIf.Argument.IsStringEmpty(input, new Exception("No command entered."));

            if (!parseLine && input.ToUpper() != "ENDIF") return;

            if(storingCommands && input.ToUpper() != "ENDLOOP")
            {
                blockQueue.Enqueue(input);
                return;
            }

            if(storingMethod && input.ToUpper() != "ENDMETHOD")
            {
                tempMethodQueue.Enqueue(input);
                return;
            }

            // Check method call
            if(input.EndsWith("()"))
            {
                if (methodsDictionary.ContainsKey(input))
                {
                    Queue<string> commands = methodsDictionary[input];
                    foreach (string line in commands)
                    {
                        ParseLine(line);
                    }
                    return;
                }

                throw new Exception("Method not found");
            }   

            if(input.StartsWith("IF"))
            {
                parseLine = checkForIfStatement(input);
            }
            else if (input.ToUpper() == "ENDIF")
            {
                parseLine = true;
            }
            else if (input.StartsWith("LOOP"))
            {
                loopCount = checkLoopCount(input);
                storingCommands = true;
            }
            else if(input.ToUpper() == "ENDLOOP")
            {
                storingCommands = false;
                for(int x = 0; x < loopCount; x++)
                {
                    foreach(string command in blockQueue.ToArray())
                    {
                        ParseLine(command);
                    }
                }
            }
            else if (input.ToUpper().StartsWith("METHOD"))
            {
                string[] parts = input.Trim().Split(" ");

                ThrowIf.Argument.ValidateExactArgumentCount(parts, 2, new Exception("Invalid Method Declaration"));

                storingMethodName = parts[1];
                if(methodsDictionary.ContainsKey(storingMethodName))
                {
                    throw new Exception("Method name already declared");
                }
                methodsDictionary.Add(storingMethodName, new Queue<string>());
                storingMethod = true;
            }
            else if(input.Equals("ENDMETHOD"))
            {
                storingMethod = false;
                methodsDictionary[storingMethodName] = new Queue<string>(tempMethodQueue);
                tempMethodQueue.Clear();

            }
            else if(input.Contains('='))
            {
                variables.ParseDeclaration(input);
            }
            else
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

        /// <summary>
        /// Parses the if statement and evaluates expression
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private bool checkForIfStatement(string input)
        {
            input = input.Replace("IF", "");

            string[] parts = input.Trim().Split(' ');

            ThrowIf.Argument.ValidateExactArgumentCount(parts, 3, new Exception("Invalid if statement."));

            string variableName = parts[0];
            string comparisonOperator = parts[1];
            int value = int.Parse(parts[2]);

            if (!variables.ContainsVariable(variableName))
            {
                throw new ArgumentException($"Variable '{variableName}' not found.");
            }

            // Validate and parse the value
            if (!int.TryParse(parts[2], out value))
            {
                throw new ArgumentException($"Invalid value '{parts[2]}'. It should be an integer.");
            }

            // Validate the comparison operator
            if (!new[] { ">", "<", "==", "!=", ">=", "<=" }.Contains(comparisonOperator))
            {
                throw new ArgumentException($"Invalid comparison operator '{comparisonOperator}'.");
            }

            // Evaluate the expression
            return ifStatement.EvaluateExpression(variableName, comparisonOperator, value);

        }

        /// <summary>
        /// Works out the amount of times the loop has to repeat, can be a raw int value or variable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int checkLoopCount(string input)
        {
            string[] parts = input.Trim().Split(" ");

            ThrowIf.Argument.ValidateExactArgumentCount(parts, 2, new Exception("Invalid Loop expression."));

            if (int.TryParse(parts[1], out int number))
            {
                return int.Parse(parts[1]);
            }
            else
            {
                if (variables.ContainsVariable(parts[1]))
                {
                    return variables.GetVariable(parts[1]);

                }

                throw new Exception("Invalid loop variable");
            }
        }

        /// <summary>
        /// Runs the program in txtBox_Program.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="NullReferenceException">Form1 is null.</exception>
        public void Run(string[] parameters)
        {
            #region Run Command Validation
            ThrowIf.Argument.ValidateExactArgumentCount(parameters, 0, "Run");
            #endregion

            if (form1 == null)
            {
                throw new NullReferenceException("Form1 is null.");
            }

            if(form1.Test == true)
            {
                form1.Unit_Test_btnRun_Program_Click();
            }
            else
            {           
                form1.BtnRunProgram.PerformClick();
            }
        }
    }
}
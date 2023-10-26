using System;

namespace CommandParserAssignmnet
{
    public class Command
    {
        GraphicsHandler graphicsHandler;
        ShapeFactory shapeFactory;

        /// <summary>
        /// Constructor for the Command class.
        /// </summary>
        /// <param name="graphicsHandler"></param>
        public Command(GraphicsHandler graphicsHandler)
        {
            this.graphicsHandler = graphicsHandler;
            this.shapeFactory = new ShapeFactory();
        }

        /// <summary>
        /// Moves the pen to the specified position.
        /// </summary>
        /// <remarks>
        /// This method moves the pen to the specified position on the drawing area.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>X (int):</term>
        ///             <description>The x-coordinate to move the pen to.</description>
        ///         </item>
        ///         <item>
        ///             <term>Y (int):</term>
        ///             <description>The y-coordinate to move the pen to.</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided arguments are invalid.</exception>
        public void MoveTo(string[] args)
        {
            #region MoveTo Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 2, "MoveTo");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["X"] = new Dictionary<string, object>
                {
                    { "value", args[0] },
                    { "type", typeof(int) },
                    { "minValue", 0 },
                    { "maxValue", Globals.pictureBoxWidth }

                },
                ["Y"] = new Dictionary<string, object>
                {
                    { "value", args[1] },
                    { "type", typeof(int) },
                    { "minValue", 0 },
                    { "maxValue", Globals.pictureBoxHeight }
                }
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "MoveTo");
            #endregion

            // Validation passed, so we can parse the arguments
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);

            graphicsHandler.X = x;
            graphicsHandler.Y = y;
        }

        /// <summary>
        /// Draws a line from the current position to the specified position.
        /// </summary>
        /// <remarks>
        /// This method draws a straight line from the current pen position to the specified destination coordinates on the drawing area.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>X (int):</term>
        ///             <description>The x-coordinate of the destination point.</description>
        ///         </item>
        ///         <item>
        ///             <term>Y (int):</term>
        ///             <description>The y-coordinate of the destination point.</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided arguments are invalid.</exception>
        public void DrawTo(string[] args)
        {
            #region DrawTo Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 2, "DrawTo");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["X"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(int) },
                    { "minValue", 0 },
                    { "maxValue", Globals.pictureBoxWidth }
                },
                ["Y"] = new Dictionary<string, object>
                {
                    { "value", args[1].Trim() },
                    { "type", typeof(int) },
                    { "minValue", 0 },
                    { "maxValue", Globals.pictureBoxHeight }
                }
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "DrawTo");
            #endregion

            // Validation passed, so we can parse the arguments
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);

            graphicsHandler.drawLine(x, y);

            graphicsHandler.X = x;
            graphicsHandler.Y = y;
        }

        /// <summary>
        /// Clears the graphics area, removing all drawings and resetting the pen position.
        /// </summary>
        /// <remarks>
        /// This method clears the entire graphics area, removing any previously drawn shapes or lines. It doesn't reset the pen position to the origin (Global.startingX, Global.startingY).
        /// </remarks>
        /// <param name="args">No arguments are required for this method.</param>
        /// <exception cref="ArgumentException">Thrown if the arguments are provided.</exception>
        public void Clear(string[] args)
        {
            #region Clear Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 0, "Clear");
            #endregion

            graphicsHandler.getGraphics().Clear(Globals.pictureBoxColor);

        }

        /// <summary>
        /// Resets the position of the pen to the starting position (Global.startingX, Global.startingY).
        /// </summary>
        /// <remarks>
        /// This method resets the pen's position to the origin (Global.startingX, Global.startingY). on the graphics area. It does not clear the drawings but moves the pen back to the starting point.
        /// </remarks>
        /// <param name="args">No arguments are required for this method.</param>
        /// <exception cref="ArgumentException">Thrown if the arguments are provided.</exception>

        public void Reset(string[] args)
        {
            #region Reset Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 0, "Reset");
            #endregion

            graphicsHandler.X = Globals.startingX;
            graphicsHandler.Y = Globals.startingY;
        }

        /// <summary>
        /// Sets the color of the pen used for drawing.
        /// </summary>
        /// <remarks>
        /// This method allows you to specify the color for the pen used in drawing. The color parameter is case-insensitive, and it should be a recognized color name.
        /// </remarks>
        /// <param name="args">An array of string arguments containing the color to set for the pen. E.g., ["Red"]</param>
        /// <exception cref="ArgumentException">Thrown if the provided color name is not recognized.</exception>
        public void Pen(string[] args)
        {
            #region Pen Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 1, "Pen");
            ThrowIf.Argument.InvalidColour(args[0], "colour", "Pen");
            #endregion

            // Validation passed, so we can parse the arguments
            Color colour = Color.FromName(args[0]);

            graphicsHandler.PenColour = colour;
        }

        /// <summary>
        /// Sets the fill mode for drawing shapes.
        /// </summary>
        /// <remarks>
        /// This method allows you to specify whether shapes should be filled or not when drawn. The fill parameter can be either "on" or "off" for enabling or disabling filling. Alternatively, you can specify "true" or "false" as a boolean value.
        /// The fill mode determines whether the interior of shapes will be filled with the current brush color or left unfilled.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Fill (bool):</term>
        ///             <description>Specify "on" to enable shape filling or "off" to disable filling.</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided fill mode is not recognized or cannot be parsed as a boolean.</exception>
        public void Fill(string[] args)
        {
            #region Fill Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 1, "Fill");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["Fill"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(bool) },
                    { "accept_on-off", true }
                }
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "Fill");
            #endregion

            // Validation passed, so we can parse the arguments.
            // If the argument is "on" or "off", then we can assign accordingly, otherwise we need to parse the string as a bool.
            bool fill = args[0].Equals("on", StringComparison.OrdinalIgnoreCase) || args[0].Equals("off", StringComparison.OrdinalIgnoreCase)
                ? args[0].Equals("on", StringComparison.OrdinalIgnoreCase)
                : bool.Parse(args[0]);

            graphicsHandler.Fill = fill;
        }

        /// <summary>
        /// Draws a circle with the specified radius.
        /// </summary>
        /// <remarks>
        /// This method allows you to draw a circle with the specified radius using the current pen and fill settings. The radius must be a positive integer value.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Radius (int):</term>
        ///             <description>The radius of the circle to draw (must be a positive integer).</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided radius is not a positive integer.</exception>
        public void Circle(string[] args)
        {
            #region Circle Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 1, "circle");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["Radius"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(int) },
                },
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "circle");
            #endregion

            // Validation passed, so we can parse the arguments
            int radius = int.Parse(args[0]);

            Shape circle = shapeFactory.getShape("circle", paramsToArray(radius));
            circle.Draw(graphicsHandler);
        }

        /// <summary>
        /// Draws a rectangle with the specified width and height.
        /// </summary>
        /// <remarks>
        /// This method allows you to draw a rectangle with the specified width and height using the current pen and fill settings. The width and height must be positive integer values.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>Width (int):</term>
        ///             <description>The width of the rectangle to draw (must be a positive integer).</description>
        ///         </item>
        ///         <item>
        ///             <term>Height (int):</term>
        ///             <description>The height of the rectangle to draw (must be a positive integer).</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided width or height is not a positive integer.</exception>
        public void Rectangle(string[] args)
        {
            #region Rectangle Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 2, "rectangle");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["Width"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(int) }
                },
                ["Height"] = new Dictionary<string, object>
                {
                    { "value", args[1].Trim() },
                    { "type", typeof(int) }
                },
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "rectangle");
            #endregion

            // Validation passed, so we can parse the arguments
            int width = int.Parse(args[0]);
            int height = int.Parse(args[1]);

            Shape rectangle = shapeFactory.getShape("rectangle", paramsToArray(width, height));
            rectangle.Draw(graphicsHandler);
        }

        /// <summary>
        /// Draws a square with the specified side length.
        /// </summary>
        /// <remarks>
        /// This method allows you to draw a square with the specified side length using the current pen and fill settings. The side length must be a positive integer value.
        /// </remarks>
        /// <param name="args">An array of arguments with the following format:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>SideLength (int):</term>
        ///             <description>The length of each side of the square to draw (must be a positive integer).</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided side length is not a positive integer.</exception>
        public void Square(string[] args)
        {
            #region Square Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 1, "square");

            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["SideLength"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(int) }
                },
            };

            ThrowIf.Argument.validateArguments(argumentValidator, "square");
            #endregion

            // Validation passed, so we can parse the arguments
            int sideLength = int.Parse(args[0]);

            Shape square = shapeFactory.getShape("square", paramsToArray(sideLength));
            square.Draw(graphicsHandler);
        }

        /// <summary>
        /// Draws a triangle with specified side lengths.
        /// </summary>
        /// <remarks>
        /// This method allows you to draw a triangle based on the provided side lengths. The number of arguments determines the type of triangle to be drawn:
        /// <list type="bullet">
        ///     <item>
        ///         <term>1 Argument:</term>
        ///         <description>Draws an equilateral triangle with all sides of equal length.</description>
        ///     </item>
        ///     <item>
        ///         <term>2 Arguments:</term>
        ///         <description>Draws an isosceles triangle with two sides of equal length.</description>
        ///     </item>
        ///     <item>
        ///         <term>3 Arguments:</term>
        ///         <description>Draws a general triangle with all sides of different lengths.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        /// <param name="args">An array of arguments with the following format based on the number of arguments provided:
        ///     <list type="bullet">
        ///         <item>
        ///             <term>1 Argument (int):</term>
        ///             <description>The length of all sides of the equilateral triangle (must be a positive integer).</description>
        ///         </item>
        ///         <item>
        ///             <term>2 Arguments (int, int):</term>
        ///             <description>The lengths of the two equal sides of the isosceles triangle (both must be positive integers).</description>
        ///         </item>
        ///         <item>
        ///             <term>3 Arguments (int, int, int):</term>
        ///             <description>The lengths of all three sides of the general triangle (all must be positive integers).</description>
        ///         </item>
        ///     </list>
        /// </param>
        /// <exception cref="ArgumentException">Thrown if the provided arguments are invalid.</exception>
        public void Triangle(string[] args)
        {
            #region Triangle Argument Validation

            if (args.Length < 1 || args.Length > 3)
            {
                throw new ArgumentException("Invalid number of arguments provided for triangle.");
            }

            // Define the argument names and their corresponding types
            var argumentNames = new string[] { "SideA", "SideB", "SideC" };
            var argumentTypes = new Type[] { typeof(int), typeof(int), typeof(int) };

            // Create a list of argument dictionaries based on the number of provided arguments
            var argumentValidator = new Dictionary<string, Dictionary<string, object>>();

            for (int i = 0; i < args.Length; i++)
            {
                argumentValidator.Add(argumentNames[i], new Dictionary<string, object>
                {
                    { "value", args[i].Trim() },
                    { "type", argumentTypes[i] }
                });
            }

            ThrowIf.Argument.validateArguments(argumentValidator, "triangle");
            #endregion

            // Validation passed, so we can parse the arguments
            Shape triangle;

            if (args.Length == 1)
            {
                int sideLength = int.Parse(args[0]);
                triangle = shapeFactory.getShape("equil_triangle", paramsToArray(sideLength, graphicsHandler.X, graphicsHandler.Y));
            }
            else if (args.Length == 2)
            {
                int sideA = int.Parse(args[0]);
                int sideB = int.Parse(args[1]);
                triangle = shapeFactory.getShape("isos_triangle", paramsToArray(sideA, sideB, graphicsHandler.X, graphicsHandler.Y));
            }
            else
            {
                int sideA = int.Parse(args[0]);
                int sideB = int.Parse(args[1]);
                int sideC = int.Parse(args[2]);
                triangle = shapeFactory.getShape("triangle", paramsToArray(sideA, sideB, sideC, graphicsHandler.X, graphicsHandler.Y));
            }

            triangle.Draw(graphicsHandler);
        }

        /// <summary>
        /// Displays a list of available commands to the user.
        /// </summary>
        /// <param name="args">Optional arguments (none required for this command).</param>
        /// <remarks>
        /// This method provides the user with a list of recognized commands that can be entered into the program. It is executed by typing 'help' in the program interface.
        /// The list includes commands for drawing, pen and fill settings, as well as the 'help' command itself.
        /// </remarks>
        /// <param name="args">Optional arguments (no arguments are required for this command).</param>
        public void Help(string[] args)
        {
            #region Help Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args, 0, "Help");
            #endregion

            Console.WriteLine("The following commands are available:");
            Console.WriteLine("moveTo X,Y");
            Console.WriteLine("drawTo X,Y");
            Console.WriteLine("reset");
            Console.WriteLine("clear");
            Console.WriteLine("pen colour");
            Console.WriteLine("fill on/off");
            Console.WriteLine("circle radius");
            Console.WriteLine("rectangle width,height");
            Console.WriteLine("square sideLength");
            Console.WriteLine("triangle sideA,sideB,sideC");
            Console.WriteLine("help");
        }

        /// <summary>
        /// Takes a variable number of arguments and returns them as an array.
        /// </summary>
        /// <param name="args"></param>
        /// <returns> An array of integers containing the provided arguments.</returns>
        private int[] paramsToArray(params int[] args)
        {
            return args;
        }
    }
}
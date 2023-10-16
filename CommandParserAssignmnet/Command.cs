using System;

namespace CommandParserAssignmnet
{
    public class Command
    {
        GraphicsHandler graphicsHandler;

        /// <summary>
        /// Constructor for the Command class.
        /// </summary>
        /// <param name="graphicsHandler"></param>
        public Command(GraphicsHandler graphicsHandler)
        {
           this.graphicsHandler = graphicsHandler;
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
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 2, "MoveTo");
     
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
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 2, "DrawTo");

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
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 0, "Clear");
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
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 0, "Reset");
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
        /// <exception cref="ArgumentException">Thrown if the provided color name is not recognized.</exception
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

        public void Fill(string[] args)
        {
            #region Fill Argument Validation
            ThrowIf.Argument.ValidateExactArgumentCount(args.Length, 1, "Fill");
            
            var argumentValidator = new Dictionary<string, Dictionary<string, object>>
            {
                ["Fill"] = new Dictionary<string, object>
                {
                    { "value", args[0].Trim() },
                    { "type", typeof(bool) }
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
    }
}
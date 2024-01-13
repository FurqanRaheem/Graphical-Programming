using System.Drawing;
using System.Runtime.CompilerServices;

namespace Tests
{
    /// <summary>
    /// Unit tests for the Parser class, which parses drawing commands and updates the GraphicsHandler.
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        private GraphicsHandler graphicsHandler;
        private Parser parser;
        private Variables variables;

        [TestInitialize]
        public void TestInitialize()
        { 
            Globals.pictureBoxWidth = 100;
            Globals.pictureBoxHeight = 100;
            Globals.pictureBoxColor = Color.Black;

            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler);
            variables = Variables.Instance;
            variables.clearVariables();
        }

        /// <summary>
        /// Tests the ParseLine method with an unrecognized command. Expects an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("invalid")]
        [DataRow("crcle 50")]
        [DataRow("movto 100,100")]
        public void ParseLine_UnrecognizedCommand_ThrowsArgumentException(string command)
        {  
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseLine method for the "moveTo" command, ensuring it updates the cursor position correctly.
        /// </summary>
        [TestMethod]
        public void ParseLine_MoveTo_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("moveTo 50,50");

            // Assert
            // Implement assertions to check if the "moveTo" command was parsed correctly.
            Assert.AreEqual(50, graphicsHandler.X);
            Assert.AreEqual(50, graphicsHandler.Y);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "moveTo" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("moveTo")]
        [DataRow("moveTo 50")]
        [DataRow("moveTo 50,50,50")]
        public void ParseLine_MoveTo_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseLine method for the "drawTo" command, ensuring it updates the cursor position correctly and draws on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawTo_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("drawTo 50,50");

            // Assert
            // Implement assertions to check if the "drawTo" command was parsed correctly.
            Assert.AreEqual(50, graphicsHandler.X);
            Assert.AreEqual(50, graphicsHandler.Y);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "drawTo" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("drawTo")]
        [DataRow("drawTo 50")]
        [DataRow("drawTo 50,50,50")]
        public void ParseLine_DrawTo_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseLine method for the "reset" command, ensuring it resets the cursor positions to their starting values and maintains the drawing on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_Reset_Command_ParsesCorrectly()
        { 
            // Act
            parser.ParseLine("drawTo 100,100"); // Draw a line to make sure the cursor positions are not at the starting positions
            parser.ParseLine("reset");

            // Assert
            // Implement assertions to check if the "reset" command was parsed correctly.
            Assert.AreEqual(Globals.startingX, graphicsHandler.X);
            Assert.AreEqual(Globals.startingY, graphicsHandler.Y);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "reset" command with extra parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseLine_Reset_Command_With_Extra_Parameters_ThrowsArgumentException()
        {
            // Act & Assert
            parser.ParseLine("reset 100,100");
        }

        /// <summary>
        /// Tests the ParseLine method for the "clear" command, ensuring it clears the bitmap and maintains cursor positions.
        /// </summary>
        [TestMethod]
        public void ParseLine_Clear_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("drawTo 100,100"); // Draw a line to make sure the bitmap is not all black
            parser.ParseLine("clear");

            // Assert
            Assert.AreEqual(100, graphicsHandler.X);
            Assert.AreEqual(100, graphicsHandler.Y);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "clear" command with extra parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseLine_Clear_Command_With_Extra_Parameters_ThrowsArgumentException()
        { 
            // Act & Assert
            parser.ParseLine("clear 100,100");
        }

        /// <summary>
        /// Tests the ParseLine method for the "pen" command, ensuring it sets the pen color and maintains the drawing on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_Pen_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("pen red");
            parser.ParseLine("drawTo 100,100"); // Draw a line to make sure the pen colour has changed

            // Assert
            Assert.AreEqual(Color.Red, graphicsHandler.PenColour);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "pen" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("pen")]
        [DataRow("pen invalid")]
        public void ParseLine_Pen_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseLine method for the "fill" command, ensuring it sets the "Fill" property correctly based on different valid input variations.
        /// </summary>
        [TestMethod]
        [DataRow("fill on")]
        [DataRow("fill off")]
        [DataRow("fill true")]
        [DataRow("fill false")]
        public void ParseLine_Fill_Command_ParsesCorrectly(string command)
        {
            // Act
            parser.ParseLine(command);

            bool expectedFill = command.EndsWith("on") || command.EndsWith("true");

            // Assert
            Assert.AreEqual(graphicsHandler.Fill, expectedFill);
        }

        /// <summary>
        /// Tests the ParseLine method for the "fill" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("fill")]
        [DataRow("fill invalid")]
        [DataRow("fill 1")]
        [DataRow("fill 0")]
        public void ParseLine_Fill_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseLine method for the "circle" command, ensuring it correctly draws a circle on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawCircle_Command_ParsesCorrectly()
        {
            int radius = 50;
            // Act: Parse a command to draw a circle
            parser.ParseLine($"circle {radius}");

            Bitmap bitmap = graphicsHandler.getBitmap();

            int expectedX = graphicsHandler.X - radius;
            int expectedY = graphicsHandler.Y - radius;
            int expectedWidth = radius * 2;
            int expectedHeight = radius * 2;
            int penColor = graphicsHandler.PenColour.ToArgb();
            bool isBitmapAllBlack = true;
            
            // Check if there's an ellipse (circle) with the expected parameters and pen color in the bitmap
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    int pixelColor = bitmap.GetPixel(x, y).ToArgb();
                    // Check if the pixel is within the expected circle and has the expected pen color
                    if (x >= expectedX && x <= (expectedX + expectedWidth) &&
                        y >= expectedY && y <= (expectedY + expectedHeight) &&
                        pixelColor == penColor)
                    {
                        isBitmapAllBlack = false;
                    }
                }
            }

            // Assert
            Assert.IsFalse(isBitmapAllBlack);
        }

        /// <summary>
        /// Tests the ParseLine method for the "circle" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("circle")]
        [DataRow("circle 50,50")]
        [DataRow("circle fifty")]
        public void ParseLine_DrawCircle_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "rectangle" command with the "fill off" modifier, ensuring it correctly draws an empty rectangle on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawRectangle_Fill_Off_Command_ParsesCorrectly()
        {
            int width = 50;
            int height = 100;
            // Act: Parse a command to draw a rectangle
            parser.ParseLine($"rectangle {width},{height}");

            Bitmap bitmap = graphicsHandler.getBitmap();
            int penColor = graphicsHandler.PenColour.ToArgb();
            int expectedX = graphicsHandler.X;
            int expectedY = graphicsHandler.Y;
           
            // Check if there's a rectangle with the expected parameters and pen color in the bitmap
            // Since this rectangle is hollow, loop through the outline
            int[] arrayX = { expectedX, expectedX + width };
            int[] arrayY = { expectedY, expectedY + height };

            for (int x = 0; x < arrayX.Length; x++)
            {
                for (int y = 0; y < arrayY.Length; y++)
                {
                    Assert.AreEqual(penColor, bitmap.GetPixel(x, y).ToArgb());
                }
            }
        }

        /// <summary>
        /// Tests the ParseLine method for the "rectangle" command with the "fill on" modifier, ensuring it correctly draws a filled rectangle on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawRectangle_Fill_On_Command_ParsesCorrectly()
        {
            int width = 50;
            int height = 100;
            // Act: Parse a command to draw a rectangle
            parser.ParseLine($"fill on");
            parser.ParseLine($"rectangle {width},{height}");

            Bitmap bitmap = graphicsHandler.getBitmap();
            int penColor = graphicsHandler.PenColour.ToArgb();
            int expectedX = graphicsHandler.X;
            int expectedY = graphicsHandler.Y;

            // Check if there's a rectangle with the expected parameters and pen color in the bitmap
            // Since this rectangle is filled, loop through the entire rectangle
            for (int x = expectedX; x < expectedX + width; x++)
            {
                for (int y = expectedY; y < expectedY + height; y++)
                {
                    Assert.AreEqual(penColor, bitmap.GetPixel(x, y).ToArgb());
                }
            }
        }

        /// <summary>
        /// Tests the ParseLine method for the "rectangle" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("rectangle")]
        [DataRow("rectangle 50")]
        [DataRow("rectangle 50,50,50")]
        [DataRow("rectangle fifty")]
        public void ParseLine_DrawRectangle_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "square" command with the "fill off" modifier, ensuring it correctly draws an empty square on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawSquare_Fill_Off_Command_ParsesCorrectly()
        {
            int width = 50;
            // Act: Parse a command to draw a square
            parser.ParseLine($"square {width}");

            Bitmap bitmap = graphicsHandler.getBitmap();
            int penColor = graphicsHandler.PenColour.ToArgb();
            int expectedX = graphicsHandler.X;
            int expectedY = graphicsHandler.Y;

            // Check if there's a square with the expected parameters and pen color in the bitmap
            // Since this square is hollow, loop through the outline
            int[] arrayX = { expectedX, expectedX + width };
            int[] arrayY = { expectedY, expectedY + width };

            for (int x = 0; x < arrayX.Length; x++)
            {
                for (int y = 0; y < arrayY.Length; y++)
                {
                    Assert.AreEqual(penColor, bitmap.GetPixel(x, y).ToArgb());
                }
            }
        }

        /// <summary>
        /// Tests the ParseLine method for the "square" command with the "fill on" modifier, ensuring it correctly draws a filled square on the bitmap.
        /// </summary>
        [TestMethod]
        public void ParseLine_DrawSquare_Fill_On_Command_ParsesCorrectly()
        {
            int width = 50;
            // Act: Parse a command to draw a square
            parser.ParseLine($"fill on");
            parser.ParseLine($"square {width}");

            Bitmap bitmap = graphicsHandler.getBitmap();
            int penColor = graphicsHandler.PenColour.ToArgb();
            int expectedX = graphicsHandler.X;
            int expectedY = graphicsHandler.Y;

            // Check if there's a square with the expected parameters and pen color in the bitmap
            // Since this square is filled, loop through the entire square
            for (int x = expectedX; x < expectedX + width; x++)
            {
                for (int y = expectedY; y < expectedY + width; y++)
                {
                    Assert.AreEqual(penColor, bitmap.GetPixel(x, y).ToArgb());
                }
            }
        }

        /// <summary>
        /// Tests the ParseLine method for the "square" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("square")]
        [DataRow("square 50,50")]
        [DataRow("square 50,50,50")]
        [DataRow("square fifty")]
        public void ParseLine_DrawSquare_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "triangle" command with valid parameters, ensuring it correctly draws a triangle on the bitmap.
        /// </summary>
        [TestMethod]
        [DataRow("triangle 50")]
        [DataRow("triangle 50,60")]
        [DataRow("triangle 50,60,50")]
        public void ParseLine_DrawTriangle_Command_ParsesCorrectly(string command)
        {
            // Act
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "triangle" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("triangle")]
        [DataRow("triangle 50,50,50,50")]
        [DataRow("triangle 50,50,50,50,50")]
        [DataRow("triangle fifty")]
        public void ParseLine_DrawTriangle_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "help" command, ensuring it correctly displays help information.
        /// </summary>
        [TestMethod]
        public void ParseLine_Help_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("help");

            // Assert
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "help" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("help 50")]
        [DataRow("help 50,50")]
        [DataRow("help 50,50,50")]
        [DataRow("help fifty")]
        public void ParseLine_Help_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseLine method for the "run" command, ensuring it correctly executes a program with multiple commands and updates the state accordingly.
        /// </summary>
        [TestMethod]
        public void ParseLine_Run_Command_ParsesCorrectly()
        {
            // Setup
            Form1 form1 = new Form1(true);
            Parser parser = form1.Parser;
            GraphicsHandler graphicsHandler = form1.GraphicsHandler;
           
            form1.TxtBoxProgramText = "drawTo 50,50\r\npen red\r\nrectangle 50,50\r\nfill on";

            // Act
            parser.ParseLine("run");

            // Assert
            Assert.AreEqual(50, graphicsHandler.X);
            Assert.AreEqual(50, graphicsHandler.Y);
            Assert.AreEqual(Color.Red, graphicsHandler.PenColour);
            Assert.AreEqual(graphicsHandler.Fill, true);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }


        /// <summary>
        /// Tests the ParseLine method for the "run" command with various invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        /// <param name="command">The command.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("run 50")]
        [DataRow("run 50,50")]
        [DataRow("run 50,50,50")]
        [DataRow("run fifty")]
        public void ParseLine_Run_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseProgram method to ensure it correctly parses and executes a program with multiple commands, updating the state accordingly.
        /// </summary>
        [TestMethod]
        public void ParseProgram_Multiple_Commands_ParsesCorrectly()
        {
            // Act
            parser.ParseProgram("moveTo 50,50\r\ndrawTo 100,100\r\npen red\r\nrectangle 50,50\r\nfill on\r\nsquare 50\r\ntriangle 50,50,50\r\nhelp");

            // Assert
            Assert.AreEqual(100, graphicsHandler.X);
            Assert.AreEqual(100, graphicsHandler.Y);
            Assert.AreEqual(Color.Red, graphicsHandler.PenColour);
            Assert.AreEqual(graphicsHandler.Fill, true);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseProgram method with a program containing invalid commands, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseProgram_Multiple_Commands_With_Invalid_Commands_ParsesCorrectly()
        {
            // Act
            parser.ParseProgram("moveTo 50,50\r\ndrawTo 100,100\r\npen red\r\nrectangle 50,50\r\nfill on\r\nsquare 50\r\ntriangle 50,50,50\r\nhelp\r\ninvalid");

            // Assert
            Assert.AreEqual(100, graphicsHandler.X);
            Assert.AreEqual(100, graphicsHandler.Y);
            Assert.AreEqual(Color.Red, graphicsHandler.PenColour);
            Assert.AreEqual(graphicsHandler.Fill, true);
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }


        /// <summary>
        /// Tests the ParseLine method for variable declaration, ensuring it correctly adds or updates a variable in the Variables class.
        /// </summary>
        [TestMethod]
        public void ParseLine_VariableDeclaration_Command_ParsesCorrectly()
        {
            // Arrange
            string variableDeclaration = "counter = 10";

            // Act
            parser.ParseLine(variableDeclaration);

            // Assert
            Assert.IsTrue(variables.ContainsVariable("counter"));
            Assert.AreEqual(10, variables.GetVariable("counter"));
        }

        /// <summary>
        /// Tests the ParseLine method for variable declaration with invalid parameters, ensuring it throws an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("= 10")]
        [DataRow("counter =")]
        [DataRow("counter = ten")]
        public void ParseLine_VariableDeclaration_Command_With_Invalid_Parameters_ThrowsArgumentException(string variableDeclaration)
        {
            // Act & Assert
            parser.ParseLine(variableDeclaration);
        }

        /// <summary>
        /// Tests the ParseLine method for updating an existing variable, ensuring it correctly modifies the variable value in the Variables class.
        /// </summary>
        [TestMethod]
        public void ParseLine_VariableUpdate_Command_ParsesCorrectly()
        {
            // Arrange
            variables.AddVariable("counter", 5);
            string variableUpdate = "counter = 15";

            // Act
            parser.ParseLine(variableUpdate);

            // Assert
            Assert.IsTrue(variables.ContainsVariable("counter"));
            Assert.AreEqual(15, variables.GetVariable("counter"));
        }

        /// <summary>
        /// Tests the ParseProgram method for variable declaration and usage in a drawing command, ensuring it correctly updates the state.
        /// </summary>
        [TestMethod]
        public void ParseProgram_VariableUsageInDrawingCommand_ParsesCorrectly()
        {
            // Arrange
           string program = "size = 50\r\ncircle size";
            // Act
            parser.ParseProgram(program);

            // Assert
            Assert.IsTrue(variables.ContainsVariable("size"));
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseProgram method for IF statements, ensuring it correctly evaluates the condition and executes the correct commands.
        /// </summary>
        [TestMethod]
        public void ParseProgram_IfStatement_True_Evaluation()
        {
            // Arrange
            string program = "size = 50\r\nIF size > 10\r\ncircle size\r\nENDIF";

            // Act
            parser.ParseProgram(program);

            // Assert
            Assert.IsTrue(variables.ContainsVariable("size"));
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseProgram method for IF statements, ensuring it correctly evaluates the condition and executes the correct commands.
        /// </summary>
        [TestMethod]
        public void ParseProgram_IfStatement_False_Evaluation()
        {
            string program = "size = 50\r\nIF size < 10\r\ncircle size\r\nENDIF";

            parser.ParseProgram(program);

            Assert.IsTrue(variables.ContainsVariable("size"));
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

        /// <summary>
        /// Tests the ParseProgram method for IF statements with invalid parameters, ensuring it throws an Exception.
        /// </summary>
        /// <param name="command"></param>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("IF 50")]
        [DataRow("IF 50,50")]
        [DataRow("IF 50,50,50")]
        [DataRow("IF fifty")]
        public void ParseProgram_IfStatement_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the ParseProgram method for LOOP statements, ensuring it correctly loops the specified amount and executes the commands within.
        /// Tests by checking the fill property and the bitmap for drawing. Fill property is only set to true within the loop in the second iteration.
        /// </summary>
        [TestMethod]
        public void ParseProgram_LoopStatement()
        {
            string program = "size = 50\r\nLOOP 2\r\nIF size < 30\r\nfill on\r\nENDIF\r\nIF size > 30 \r\nsquare 30\r\nENDIF\r\nsize = 20\r\nENDLOOP\r\n\r\nsquare 100";

            parser.ParseProgram(program);

            Assert.IsTrue(variables.ContainsVariable("size"));
            Assert.IsTrue(BitmapHasDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
            Assert.IsTrue(graphicsHandler.Fill);
        }

        /// <summary>
        /// Tests the ParseProgram method for LOOP statements with invalid parameters, ensuring it throws an Exception.
        /// </summary>
        /// <param name="command"></param>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("LOOP 50,50")]
        [DataRow("LOOP 50,50,50")]
        [DataRow("LOOP fifty")]
        public void ParseProgram_LoopStatement_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

        /// <summary>
        /// Tests the syntax checker functionality, doesn't execute any commands
        /// </summary>
        [TestMethod]
        public void ParseProgam_SyntaxCheck()
        {
            string program = "size = 50\r\nLOOP 2\r\nIF size < 30\r\nfill on\r\nENDIF\r\nIF size > 30 \r\nsquare 30\r\nENDIF\r\nsize = 20\r\nENDLOOP\r\n\r\nsquare 100";

            parser.ParseProgram(program, true);

            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
            Assert.IsFalse(graphicsHandler.Fill);
        }

        /// <summary>
        /// Tests that an execption is thrown when the syntax checker encounters an invalid command
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseProgram_SyntaxCheck_InvalidCommand()
        {
            string program = "size = 50\r\nLOOP 2\r\nIF size < 30\r\nfill on\r\nENDIF\r\nIF size > 30 \r\nsquare 30\r\nENDIF\r\nsize = 20\r\nENDLOOP\r\n\r\nsquare 100\r\ninvalid";

            parser.ParseProgram(program, true);
        }



        /// <summary>
        /// Helper method to check if a Bitmap contains any drawing (pixels with the specified penColor).
        /// </summary>
        /// <param name="bitmap">The Bitmap to check.</param>
        /// <param name="penColor">The pen color to search for in the Bitmap.</param>
        /// <returns>True if there is drawing in the Bitmap, otherwise false.</returns>
        private bool BitmapHasDrawing(Bitmap bitmap, Color penColour)
        {
            int penColourArgb = penColour.ToArgb();
            bool isBitmapAllBlack = true;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (penColourArgb == bitmap.GetPixel(x, y).ToArgb())
                    {
                        isBitmapAllBlack = false;
                    }
                }
            }

            return !isBitmapAllBlack;
        }

        /// <summary>
        /// Helper method to check if a Bitmap does not contain any drawing (no pixels with the specified penColor).
        /// </summary>
        /// <param name="bitmap">The Bitmap to check.</param>
        /// <param name="penColor">The pen color to search for in the Bitmap.</param>
        /// <returns>True if there is no drawing in the Bitmap, otherwise false.</returns>
        private bool BitmapHasNoDrawing(Bitmap bitmap, Color penColour)
        {
            int penColourArgb = penColour.ToArgb();
            bool isBitmapAllBlack = true;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (penColourArgb == bitmap.GetPixel(x, y).ToArgb())
                    {
                        isBitmapAllBlack = false;
                    }
                }
            }

            return isBitmapAllBlack;
        }
    }
}

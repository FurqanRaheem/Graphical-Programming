using System.Drawing;
namespace Tests
{
    [TestClass]
    public class ParserTests
    {
        private GraphicsHandler graphicsHandler;
        private Parser parser;

        [TestInitialize]
        public void TestInitialize()
        { 
            Globals.pictureBoxWidth = 100;
            Globals.pictureBoxHeight = 100;
            Globals.pictureBoxColor = Color.Black;

            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler);
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseLine_Reset_Command_With_Extra_Parameters_ThrowsArgumentException()
        {
            // Act & Assert
            parser.ParseLine("reset 100,100");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseLine_Clear_Command_With_Extra_Parameters_ThrowsArgumentException()
        { 
            // Act & Assert
            parser.ParseLine("clear 100,100");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("pen")]
        [DataRow("pen invalid")]
        public void ParseLine_Pen_Command_With_Invalid_Parameters_ThrowsArgumentException(string command)
        {
            // Act & Assert
            parser.ParseLine(command);
        }

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

        [TestMethod]
        public void ParseLine_Help_Command_ParsesCorrectly()
        {
            // Act
            parser.ParseLine("help");

            // Assert
            Assert.IsTrue(BitmapHasNoDrawing(graphicsHandler.getBitmap(), graphicsHandler.PenColour));
        }

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

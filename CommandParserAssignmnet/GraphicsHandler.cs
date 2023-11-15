using System;
using System.Drawing;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Handles all the graphics drawing.
    /// </summary>
    public class GraphicsHandler
    {
        /// <summary>
        /// The bitmap used for drawing.
        /// </summary>
        private Bitmap bitmap;

        /// <summary>
        /// The graphics object used for drawing on the bitmap.
        /// </summary>
        private Graphics graphics;

        /// <summary>
        /// The color of the pen used for drawing shapes.
        /// </summary>
        protected Color penColour;

        /// <summary>
        /// The pen object used for drawing lines and borders of shapes.
        /// </summary>
        protected Pen pen;

        /// <summary>
        /// The brush object used for filling shapes.
        /// </summary>
        protected SolidBrush brush;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GraphicsHandler"/> should fill shapes.
        /// </summary>
        /// <value>
        ///   <c>true</c> to fill shapes; otherwise, <c>false</c>.
        /// </value>
        public bool Fill { get; set; }

        /// <summary>
        /// The X-coordinate of the current drawing position.
        /// </summary>
        protected int x = Globals.startingX;

        /// <summary>
        /// The Y-coordinate of the current drawing position.
        /// </summary>
        protected int y = Globals.startingY;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicsHandler"/> class.
        /// </summary>
        public GraphicsHandler()
        {
            this.bitmap = new Bitmap(Globals.pictureBoxWidth, Globals.pictureBoxHeight);
            this.graphics = Graphics.FromImage(this.bitmap);

            this.penColour = Color.White;
            this.pen = new Pen(penColour, 3);
            this.brush = new SolidBrush(penColour);
        }

        /// <summary>
        /// Gets or sets the X-coordinate of the current drawing position.
        /// </summary>
        public int X
        {
            get { return x; }
            set { if (value >= 0) { x = value; } }
        }

        /// <summary>
        /// Gets or sets the Y-coordinate of the current drawing position.
        /// </summary>
        public int Y
        {
            get { return y; }
            set { if (value >= 0) { y = value; } }
        }

        /// <summary>
        /// Gets or sets the current pen color used for drawing shapes.
        /// </summary>
        public Color PenColour
        {
            get { return penColour; }
            set { penColour = value; pen.Color = value; brush.Color = value; }
        }

        /// <summary>
        /// Gets the underlying bitmap that stores the graphics.
        /// </summary>
        /// <returns>The bitmap used for drawing.</returns>
        public Bitmap getBitmap()
        {
            return bitmap;
        }

        /// <summary>
        /// Gets the graphics object used for drawing.
        /// </summary>
        /// <returns>The graphics object used for drawing.</returns>
        public Graphics getGraphics()
        {
            return graphics;
        }

        /// <summary>
        /// Draws a line from the current position to the specified endpoint.
        /// </summary>
        /// <param name="endX">The X-coordinate of the endpoint.</param>
        /// <param name="endY">The Y-coordinate of the endpoint.</param>
        public void drawLine(int endX, int endY)
        { 
            this.graphics.DrawLine(pen, X, Y, endX, endY);
        }

        /// <summary>
        /// Draws a circle with the given radius.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public void drawCircle(int radius)
        {
            int diameter = radius * 2;

            // Offset the X and Y coordinates so that it is drawn from the middle of bounding box
            int offsetX = X - radius;
            int offsetY = Y - radius;

            if (Fill)
            {
                this.graphics.FillEllipse(brush, offsetX, offsetY, diameter, diameter);
            }
            else
            {
                this.graphics.DrawEllipse(pen, offsetX, offsetY, diameter, diameter);
            }
        }

        /// <summary>
        /// Draws a rectangle with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void drawRectangle(int width, int height)
        {
            if (Fill)
            {
                this.graphics.FillRectangle(brush, X, Y, width, height);
            }
            else
            {
                this.graphics.DrawRectangle(pen, X, Y, width, height);
            }
        }

        /// <summary>
        /// Draws a triangle defined by the given points.
        /// </summary>
        /// <param name="points">An array of points defining the vertices of the triangle.</param>
        public void drawTriangle(PointF[] points)
        {
            if (Fill)
            {
                this.graphics.FillPolygon(brush, points);
            }
            else
            {
                this.graphics.DrawPolygon(pen, points);
            }
        }

    }
}

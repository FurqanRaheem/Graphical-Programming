using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents a rectangle shape that can be drawn on a graphics surface.
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.Shape" />
    class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        private int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        private int Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle() : base()
        {
            Width = 1;
            Height = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rectangle(int width, int height) : base()
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Draws the shape on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics handler used to draw the shape.</param>
        public override void Draw(GraphicsHandler graphics)
        {
            graphics.drawRectangle(Width, Height);
        }
    }
}

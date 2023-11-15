using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents a circle shape that can be drawn on a graphics surface.
    /// </summary>
    class Circle : Shape
    {
        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        private int Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with a default radius of 1.
        /// </summary>
        public Circle() : base()
        {
            Radius = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(int radius) : base()
        {
            Radius = radius;
        }

        /// <summary>
        /// Draws the circle on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics handler used to draw the circle.</param>
        public override void Draw(GraphicsHandler graphics)
        {
            graphics.drawCircle(Radius);
        }
    }
}

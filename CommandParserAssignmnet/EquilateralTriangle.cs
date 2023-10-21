using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents an equilateral triangle shape that can be drawn on a graphics surface.
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.Triangle" />
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquilateralTriangle"/> class.
        /// </summary>
        public EquilateralTriangle(): base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EquilateralTriangle"/> class.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public EquilateralTriangle(int a, int x, int y) : base(a, x, y) { }

        /// <summary>
        /// Calculates the points of an equilateral triangle.
        /// </summary>
        public override void calculateTrianglePoints()
        {
            // Point A
            Points[0] = new PointF(StartingX, StartingY);

            // Use Side1 as the side length
            float s = SideA;

            // Calculate Point B
            Points[1] = new PointF(StartingX + s, StartingY);

            // Calculate Point C
            float angleInRadians = (float)Math.PI / 3; // 60 degrees in radians
            float deltaX = s * (float)Math.Cos(angleInRadians);
            float deltaY = s * (float)Math.Sin(angleInRadians);
            Points[2] = new PointF(StartingX + deltaX, StartingY - deltaY);
        }

        /// <summary>
        /// Draws the shape on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics handler used to draw the shape.</param>
        public override void Draw(GraphicsHandler graphics)
        {
            base.Draw(graphics);
        }
    }
}

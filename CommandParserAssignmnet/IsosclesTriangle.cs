using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents an isosceles triangle shape that can be drawn on a graphics surface.
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.Triangle" />
    class IsoscelesTriangle : Triangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsoscelesTriangle"/> class.
        /// </summary>
        public IsoscelesTriangle(): base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IsoscelesTriangle"/> class.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public IsoscelesTriangle(int a, int b, int x, int y) : base(a, b, x, y) { }

        /// <summary>
        /// Calculates the points of an isoscles triangle.
        /// </summary>
        public override void calculateTrianglePoints()
        {
            // Calculate the coordinates of the top vertex (point A)
            PointF pointA = new PointF(StartingX, StartingY);
            Points[0] = pointA;

            // SideA is the base of the triangle
            float baseLength = SideA;

            // SideB is the height of the triangle
            float height = SideB;

            // Calculate the coordinates of point B
            PointF pointB = new PointF(pointA.X - baseLength / 2, pointA.Y + height);
            Points[1] = pointB;

            // Calculate the coordinates of point C
            PointF pointC = new PointF(pointA.X + baseLength / 2, pointA.Y + height);
            Points[2] = pointC;
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

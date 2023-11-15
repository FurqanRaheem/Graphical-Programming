using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents a triangle shape that can be drawn on a graphics surface.
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.Shape" />
    class Triangle : Shape
    {
        /// <summary>
        /// Gets or sets the side a.
        /// </summary>
        /// <value>
        /// The side a.
        /// </value>
        public int SideA { get; set; }

        /// <summary>
        /// Gets or sets the side b.
        /// </summary>
        /// <value>
        /// The side b.
        /// </value>
        public int SideB { get; set; }

        /// <summary>
        /// Gets or sets the side c.
        /// </summary>
        /// <value>
        /// The side c.
        /// </value>
        public int SideC { get; set; }

        /// <summary>
        /// Gets or sets the starting x.
        /// </summary>
        /// <value>
        /// The starting x.
        /// </value>
        public int StartingX { get; set; }

        /// <summary>
        /// Gets or sets the starting y.
        /// </summary>
        /// <value>
        /// The starting y.
        /// </value>
        public int StartingY { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public PointF[] Points { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        public Triangle() : base()
        {
            SideA = 1;
            SideB = 1;
            SideC = 1;
            StartingX = Globals.startingX;
            StartingY = Globals.startingY;
            Points = new PointF[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sideA">sideA.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Triangle(int sideA, int x, int y) : base()
        {
            SideA = sideA;
            SideB = 1;
            SideC = 1;
            StartingX = x;
            StartingY = y;
            Points = new PointF[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sideA">The side a.</param>
        /// <param name="sideB">The side b.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Triangle(int sideA, int sideB, int x, int y) : base()
        {
            SideA = sideA;
            SideB = sideB;
            SideC = 1;
            StartingX = x;
            StartingY = y;
            Points = new PointF[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sideA">The side a.</param>
        /// <param name="sideB">The side b.</param>
        /// <param name="sideC">The side c.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Triangle(int sideA, int sideB, int sideC, int x, int y) : base()
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            StartingX = x;
            StartingY = y;
            Points = new PointF[3];
        }

        /// <summary>
        /// Abstract method to calculate the points of a scalene triangle.
        /// </summary>
        public virtual void calculateTrianglePoints()
        {
            // Define the side lengths of the triangle
            float sideA = SideA;
            float sideB = SideB;
            float sideC = SideC;

            // Calculate the angle opposite using the Law of Cosines
            double angleA = Math.Acos((sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC));

            // Calculate the coordinates of the vertices
            PointF pointA = new PointF(StartingX, StartingY);
            Points[0] = pointA;

            PointF pointB = new PointF(pointA.X + sideC, pointA.Y);
            Points[1] = pointB;

            PointF pointC = new PointF(
                (float)(pointA.X + sideB * Math.Cos(angleA)),
                (float)(pointA.Y + sideB * Math.Sin(angleA))
            );
            Points[2] = pointC;
        }

        /// <summary>
        /// Draws the shape on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics handler used to draw the shape.</param>
        public override void Draw(GraphicsHandler graphics)
        {
            calculateTrianglePoints();
            graphics.drawTriangle(Points);
        }
    }
}

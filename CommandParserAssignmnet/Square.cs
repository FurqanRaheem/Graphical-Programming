using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents a square shape that can be drawn on a graphics surface.
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.Rectangle" />
    class Square : Rectangle
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        public Square() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="sideLength">Length of the side.</param>
        public Square(int sideLength) : base(sideLength, sideLength) { }

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

using System;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents an interface for shapes that can be drawn on a graphics surface.
    /// </summary>
    interface IShape
    {
        /// <summary>
        /// Draws the shape on a specified graphics surface using the provided graphics handler.
        /// </summary>
        /// <param name="graphicsHandler">The graphics handler used to draw the shape on the surface.</param>
        void Draw(GraphicsHandler graphicsHandler);
    }
}

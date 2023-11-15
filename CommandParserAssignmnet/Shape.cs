using System;

namespace CommandParserAssignmnet
{        
    /// <summary>
    /// An abstract base class for shapes that can be drawn on a graphics surface.
    /// </summary>
    abstract class Shape : IShape
    {
        /// <summary>
        /// Draws the shape on the specified graphics surface.
        /// </summary>
        /// <param name="graphics">The graphics handler used to draw the shape.</param>
        public virtual void Draw(GraphicsHandler graphics)
        {
            Font drawFont = new Font("Arial", 12);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;
            String text = this.ToString();

            graphics.getGraphics().DrawString(text, drawFont, drawBrush, graphics.X, graphics.Y, drawFormat);
        }

        /// <summary>
        /// Returns a string representation of the shape.
        /// </summary>
        /// <remarks>
        /// This method provides a string representation of the shape, removing any namespace information and displaying only the class name.
        /// </remarks>
        /// <returns>A string representation of the shape without namespace information.</returns>
        public override string ToString()
        {
            String? text = base.ToString();
            MessageBox.Show(text);
            String[] sut = text!.Split('.');
            text = sut[sut.Length - 1];
            return text;
        }
    }
}

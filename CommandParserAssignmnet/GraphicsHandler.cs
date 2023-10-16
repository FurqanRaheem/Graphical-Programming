using System;
using System.Drawing;

namespace CommandParserAssignmnet
{
    public class GraphicsHandler
    {
        private Bitmap bitmap;
        private Graphics graphics;

        protected Color penColour;
        protected Pen pen;
        protected SolidBrush brush;
        protected bool fill;
        protected int x = Globals.startingX;
        protected int y = Globals.startingY;

        public GraphicsHandler() 
        {
            this.bitmap = new Bitmap(Globals.pictureBoxWidth, Globals.pictureBoxHeight);
            this.graphics = Graphics.FromImage(this.bitmap);

            this.penColour = Color.White;
            this.pen = new Pen(penColour, 3);
            this.brush = new SolidBrush(penColour);
        }

        public bool Fill { get; set; }

        public int X
        {
            get { return x; }
            set { if (value > 0) { x = value; } }
        }

        public int Y
        {
            get { return y; }
            set { if (value > 0) { y = value; } }
        }

        public Color PenColour
        {
            get { return penColour; }
            set { penColour = value; pen.Color = value; }
        }

        public Bitmap getBitmap()
        {
            return bitmap;
        }

        public Graphics getGraphics()
        {
            return graphics;
        }

        public void drawLine(int endX, int endY)
        { 
            this.graphics.DrawLine(pen, X, Y, endX, endY);
        }
    }
}

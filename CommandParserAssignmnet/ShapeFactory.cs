using System;

namespace CommandParserAssignmnet
{
    class ShapeFactory
    {
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToLower().Trim(); 

            switch (shapeType)
            {
                case "circle":
                    return new Circle();
                default:
                    throw new ArgumentException("Invalid shape type: " + shapeType);
            }
        }
    }
}
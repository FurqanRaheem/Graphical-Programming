namespace CommandParserAssignmnet
{
    class ShapeFactory
    {
        public Shape getShape(String shapeType, int[] args)
        {
            shapeType = shapeType.ToLower().Trim();

            switch (shapeType)
            {
                case "square":
                    return new Square(args[0]);
                case "rectangle":
                    return new Rectangle(args[0], args[1]);
                case "circle":
                    return new Circle(args[0]);
                case "equil_triangle":
                    return new EquilateralTriangle(args[0], args[1], args[2]);
                case "isos_triangle":
                    return new IsoscelesTriangle(args[0], args[1], args[2], args[3]);
                case "triangle":
                    return new Triangle(args[0], args[1], args[2], args[3], args[4]);
            }

            throw new InvalidOperationException("Invalid shape");
        }
    }
}
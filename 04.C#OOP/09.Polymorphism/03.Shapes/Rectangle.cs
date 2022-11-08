namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height 
        {
            get => height;
            private set => this.height = value;
        }

        public double Width
        {
            get => width;
            private set => width = value;
        }
        public override double CalculateArea() => Width * Height;

        public override double CalculatePerimeter() => 2 * (Width + Height);

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
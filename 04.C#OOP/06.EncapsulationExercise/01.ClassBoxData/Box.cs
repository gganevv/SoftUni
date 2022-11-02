namespace _01.ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Length = lenght;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.INVALID_PARAMETHER_MESSAGE, nameof(Length)));
                }
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.INVALID_PARAMETHER_MESSAGE, nameof(Width)));
                }
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.INVALID_PARAMETHER_MESSAGE, nameof(Height)));
                }
                height = value;
            }
        }

        public double SurfaceArea() => LateralSurfaceArea() + (2 * Length * Width);
        public double LateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);
        public double Volume() => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().Trim();
        }
    }
}

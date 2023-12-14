using System;

namespace P01.ClassBoxData.Models
{
    public class Box
    {
        private const string ExeptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExeptionMessage, nameof(Length)));
                }
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExeptionMessage, nameof(Width)));
                }
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(ExeptionMessage, nameof(Height)));
                }
            }
        }

        public double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();
        public double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;
        public double Volume() => Length * Width * Height;
    }
}

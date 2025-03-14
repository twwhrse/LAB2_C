using System;

namespace GeometricShapes
{
    public class Rectangle : Figure
    {
        public double Width { get; } // Ширина в пикселях
        public double Height { get; } // Высота в пикселях

        public Rectangle(Point topLeft, double width, double height)
        {
            if (width < 0 || height < 0)
                throw new ArgumentException("Ширина и высота не могут быть отрицательными");

            CenterX = topLeft.CenterX + width / 2;
            CenterY = topLeft.CenterY + height / 2;
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            // Преобразуем ширину и высоту из пикселей в метры
            double widthMeters = Width * PixelsToMeters;
            double heightMeters = Height * PixelsToMeters;

            // Вычисляем площадь в квадратных метрах
            return widthMeters * heightMeters;
        }

        public override (double Left, double Top, double Right, double Bottom) GetBoundingBox()
        {
            return (CenterX - Width / 2, CenterY - Height / 2, CenterX + Width / 2, CenterY + Height / 2);
        }

        public override string ToString()
        {
            return $"Прямоугольник. Центр: ({CenterX}, {CenterY}). Ширина: {Width} px. Высота: {Height} px. Площадь: {Math.Round(GetArea(), 2)} м².";
        }
    }
}
using System;

namespace GeometricShapes
{
    public class Ellipse : Figure
    {
        public double RadiusX { get; } // Большая полуось в пикселях
        public double RadiusY { get; } // Малая полуось в пикселях

        public Ellipse(Point center, double radiusX, double radiusY)
        {
            if (radiusX < 0 || radiusY < 0)
                throw new ArgumentException("Радиусы не могут быть отрицательными");

            CenterX = center.CenterX;
            CenterY = center.CenterY;
            RadiusX = radiusX;
            RadiusY = radiusY;
        }

        public override double GetArea()
        {
            // Преобразуем радиусы из пикселей в метры
            double radiusXMeters = RadiusX * PixelsToMeters;
            double radiusYMeters = RadiusY * PixelsToMeters;

            // Вычисляем площадь в квадратных метрах
            return Math.PI * radiusXMeters * radiusYMeters;
        }

        public override (double Left, double Top, double Right, double Bottom) GetBoundingBox()
        {
            return (CenterX - RadiusX, CenterY - RadiusY, CenterX + RadiusX, CenterY + RadiusY);
        }

        public override string ToString()
        {
            return $"Эллипс. Центр: ({CenterX}, {CenterY}). Большая полуось: {RadiusX} px. Малая полуось: {RadiusY} px. Площадь: {Math.Round(GetArea(), 2)} м².";
        }
    }
}
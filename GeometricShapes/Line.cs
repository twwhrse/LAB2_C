using System;

namespace GeometricShapes
{
    public class Line : Figure
    {
        public Point FromPoint { get; }
        public Point ToPoint { get; }

        public Line(Point fromPoint, Point toPoint)
        {
            FromPoint = fromPoint;
            ToPoint = toPoint;
            // Центр линии — середина между двумя точками
            CenterX = (fromPoint.CenterX + toPoint.CenterX) / 2;
            CenterY = (fromPoint.CenterY + toPoint.CenterY) / 2;
        }

        public override double GetArea()
        {
            return 0; // Площадь линии равна 0
        }

        public override (double Left, double Top, double Right, double Bottom) GetBoundingBox()
        {
            return (Math.Min(FromPoint.CenterX, ToPoint.CenterX),
                   Math.Min(FromPoint.CenterY, ToPoint.CenterY),
                   Math.Max(FromPoint.CenterX, ToPoint.CenterX),
                   Math.Max(FromPoint.CenterY, ToPoint.CenterY));
        }

        public override string ToString()
        {
            return $"Линия. Начало: ({FromPoint.CenterX}, {FromPoint.CenterY}). Конец: ({ToPoint.CenterX}, {ToPoint.CenterY}). Площадь: {GetArea()} м².";
        }
    }
}
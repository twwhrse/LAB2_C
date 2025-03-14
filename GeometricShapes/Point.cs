namespace GeometricShapes
{
    public class Point : Figure
    {
        public Point(double x, double y)
        {
            CenterX = x;
            CenterY = y;
        }

        public override double GetArea()
        {
            return 0; // Площадь точки равна 0
        }

        public override (double Left, double Top, double Right, double Bottom) GetBoundingBox()
        {
            return (CenterX, CenterY, CenterX, CenterY); // Bounding box точки — это сама точка
        }

        public override string ToString()
        {
            return $"Точка. Центр: ({CenterX}, {CenterY}). Площадь: {GetArea()} м².";
        }
    }
}
namespace GeometricShapes
{
    public abstract class Figure
    {
        // Коэффициент преобразования: 1 пиксель = 0.01 метра
        protected const double PixelsToMeters = 0.01;

        // Координаты центра фигуры
        public double CenterX { get; protected set; }
        public double CenterY { get; protected set; }

        // Абстрактный метод для получения площади фигуры
        public abstract double GetArea();

        // Абстрактный метод для получения bounding box (координаты прямоугольника)
        public abstract (double Left, double Top, double Right, double Bottom) GetBoundingBox();

        // Абстрактный метод для строкового представления фигуры
        public abstract override string ToString();
    }
}
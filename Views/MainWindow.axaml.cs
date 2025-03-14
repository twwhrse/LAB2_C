using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using GeometricShapes;
using System;

namespace AvaloniaGeometryApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawCoordinateSystem(); // Отрисовка координатных плоскостей и сетки
            DrawShapes(); // Отрисовка фигур

            // Подписываемся на изменение выбора фигуры
            var shapeSelector = this.FindControl<ComboBox>("ShapeSelector");
            if (shapeSelector != null)
            {
                shapeSelector.SelectionChanged += OnShapeSelected;
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DrawCoordinateSystem()
        {
            var canvas = this.FindControl<Canvas>("DrawingCanvas");
            if (canvas == null)
            {
                Console.WriteLine("Canvas is null.");
                return;
            }

            Console.WriteLine("Drawing coordinate system...");

            // Очистка холста
            canvas.Children.Clear();

            // Настройки для осей и сетки
            var brush = Brushes.Gray; // Цвет сетки
            var axisBrush = Brushes.Black; // Цвет осей
            double step = 50; // Шаг сетки
            double thickness = 1;

            // Отрисовка сетки
            for (double x = 0; x < canvas.Bounds.Width; x += step)
            {
                var line = new Avalonia.Controls.Shapes.Line
                {
                    StartPoint = new Avalonia.Point(x, 0),
                    EndPoint = new Avalonia.Point(x, canvas.Bounds.Height),
                    Stroke = brush,
                    StrokeThickness = thickness
                };
                canvas.Children.Add(line);
            }

            for (double y = 0; y < canvas.Bounds.Height; y += step)
            {
                var line = new Avalonia.Controls.Shapes.Line
                {
                    StartPoint = new Avalonia.Point(0, y),
                    EndPoint = new Avalonia.Point(canvas.Bounds.Width, y),
                    Stroke = brush,
                    StrokeThickness = thickness
                };
                canvas.Children.Add(line);
            }

            // Отрисовка осей координат
            double centerX = canvas.Bounds.Width / 2;
            double centerY = canvas.Bounds.Height / 2;

            // Ось X (горизонтальная)
            var xAxis = new Avalonia.Controls.Shapes.Line
            {
                StartPoint = new Avalonia.Point(0, centerY),
                EndPoint = new Avalonia.Point(canvas.Bounds.Width, centerY),
                Stroke = axisBrush,
                StrokeThickness = 2
            };
            canvas.Children.Add(xAxis);

            // Ось Y (вертикальная)
            var yAxis = new Avalonia.Controls.Shapes.Line
            {
                StartPoint = new Avalonia.Point(centerX, 0),
                EndPoint = new Avalonia.Point(centerX, canvas.Bounds.Height),
                Stroke = axisBrush,
                StrokeThickness = 2
            };
            canvas.Children.Add(yAxis);

            Console.WriteLine("Coordinate system drawn.");
        }

        private void OnShapeSelected(object? sender, SelectionChangedEventArgs e)
        {
            DrawShapes(); // Перерисовка фигур при изменении выбора
        }

        private void DrawShapes()
        {
            var canvas = this.FindControl<Canvas>("DrawingCanvas");
            var shapeParameters = this.FindControl<TextBlock>("ShapeParameters");

            if (canvas == null || shapeParameters == null)
                return;

            // Очистка фигур (но не координатных плоскостей и сетки)
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                if (canvas.Children[i] is Avalonia.Controls.Shapes.Shape)
                {
                    canvas.Children.RemoveAt(i);
                }
            }

            // Получение выбранной фигуры
            var shapeSelector = this.FindControl<ComboBox>("ShapeSelector");
            if (shapeSelector == null)
                return;

            Figure? shape = null; // Используем nullable-тип

            switch (shapeSelector.SelectedIndex)
            {
                case 0: // Точка
                    shape = new GeometricShapes.Point(200, 200);
                    break;
                case 1: // Линия
                    shape = new Line(new GeometricShapes.Point(100, 100), new GeometricShapes.Point(300, 300));
                    break;
                case 2: // Эллипс
                    shape = new Ellipse(new GeometricShapes.Point(300, 200), 100, 50);
                    break;
                case 3: // Прямоугольник
                    shape = new Rectangle(new GeometricShapes.Point(400, 150), 150, 100);
                    break;
            }

            if (shape != null)
            {
                // Отрисовка фигуры
                DrawShape(canvas, shape);

                // Отображение параметров фигуры (включая площадь)
                shapeParameters.Text = shape.ToString();
            }
        }

        private void DrawShape(Canvas canvas, Figure shape)
        {
            switch (shape)
            {
                case GeometricShapes.Point point:
                    DrawPoint(canvas, point);
                    break;
                case Line line:
                    DrawLine(canvas, line);
                    break;
                case Ellipse ellipse:
                    DrawEllipse(canvas, ellipse);
                    break;
                case Rectangle rectangle:
                    DrawRectangle(canvas, rectangle);
                    break;
            }
        }

        private void DrawPoint(Canvas canvas, GeometricShapes.Point point)
        {
            var ellipse = new Avalonia.Controls.Shapes.Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(ellipse, point.CenterX - 2.5);
            Canvas.SetTop(ellipse, point.CenterY - 2.5);
            canvas.Children.Add(ellipse);
        }

        private void DrawLine(Canvas canvas, Line line)
        {
            var avaloniaLine = new Avalonia.Controls.Shapes.Line
            {
                StartPoint = new Avalonia.Point(line.FromPoint.CenterX, line.FromPoint.CenterY),
                EndPoint = new Avalonia.Point(line.ToPoint.CenterX, line.ToPoint.CenterY),
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };
            canvas.Children.Add(avaloniaLine);
        }

        private void DrawEllipse(Canvas canvas, Ellipse ellipse)
        {
            var avaloniaEllipse = new Avalonia.Controls.Shapes.Ellipse
            {
                Width = ellipse.RadiusX * 2,
                Height = ellipse.RadiusY * 2,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Canvas.SetLeft(avaloniaEllipse, ellipse.CenterX - ellipse.RadiusX);
            Canvas.SetTop(avaloniaEllipse, ellipse.CenterY - ellipse.RadiusY);
            canvas.Children.Add(avaloniaEllipse);
        }

        private void DrawRectangle(Canvas canvas, Rectangle rectangle)
        {
            var avaloniaRectangle = new Avalonia.Controls.Shapes.Rectangle
            {
                Width = rectangle.Width,
                Height = rectangle.Height,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Canvas.SetLeft(avaloniaRectangle, rectangle.CenterX - rectangle.Width / 2);
            Canvas.SetTop(avaloniaRectangle, rectangle.CenterY - rectangle.Height / 2);
            canvas.Children.Add(avaloniaRectangle);
        }
    }
}
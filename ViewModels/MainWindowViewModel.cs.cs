using GeometricShapes; // Добавьте эту строку
using ReactiveUI;

namespace AvaloniaGeometryApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private Figure? _selectedShape;
        public Figure? SelectedShape
        {
            get => _selectedShape;
            set => this.RaiseAndSetIfChanged(ref _selectedShape, value);
        }

        public MainWindowViewModel()
        {
            // Инициализация начальной фигуры (например, эллипс)
            SelectedShape = new Ellipse(new Point(150, 150), 100, 50);
        }
    }
}
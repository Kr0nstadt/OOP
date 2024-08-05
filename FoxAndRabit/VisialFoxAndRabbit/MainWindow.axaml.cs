using Avalonia.Controls;
using Avalonia.Interactivity;
using FoxAndRabit;

namespace VisualFoxAndRabbit
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static Field field = new Field(new ReadFile());
        private void ButtonClicked(object source, RoutedEventArgs args)
        {
            //тут что б поле генерилось визуально
            field.StageField();
        }
    }
}
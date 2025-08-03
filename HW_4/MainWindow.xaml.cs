using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HW_4
{
    public class ToggleButton : Button
    {
        public static SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);
        public static SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
        
        public static readonly DependencyProperty ClickToggleProperty =
            DependencyProperty.Register(
                "ToggleCount",
                typeof(bool),
                typeof(ToggleButton),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.None,
                    OnClickToggleChanged));

        public bool ToggleTrueFalse
        {
            get => (bool)GetValue(ClickToggleProperty);
            set => SetValue(ClickToggleProperty, value);
        }

        private static void OnClickToggleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ToggleButton)d;
            bool newValue = (bool)e.NewValue;

            button.Content = newValue == false ? "ВЫКЛ." : $"ВКЛ.";
            button.Background = newValue == false ? redBrush : greenBrush;
        }

        public ToggleButton()
        {
            Content = "ВЫКЛ.";
            Background = redBrush;
            
            Click += (sender, e) => ToggleTrueFalse = !ToggleTrueFalse;
        }
    }
}
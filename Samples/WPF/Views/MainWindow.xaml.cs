using FastColoredTextBox_WPF.ViewModels;
using FastColoredTextBoxNS;
using System.Windows;
using System.Windows.Forms.Integration;

namespace FastColoredTextBox_WPF
{
    public partial class MainWindow : Window
    {
        private FastColoredTextBox _ide { get; }



        public MainWindow(MainViewModel viewModel, FastColoredTextBox ide)
        {
            DataContext = viewModel;

            _ide = ide;

            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var windowsFormHost = new WindowsFormsHost
            {
                Child = _ide
            };

            FastColoredTextBoxContainer.Children.Add(windowsFormHost);
        }
    }
}

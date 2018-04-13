using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Views.Settings
{
    /// <summary>
    /// Interaction logic for TextEditor.xaml
    /// </summary>
    public partial class TextEditor : UserControl
    {
        public TextEditor(Models.Settings settings)
		{
			DataContext = settings;

			InitializeComponent();
        }
    }
}

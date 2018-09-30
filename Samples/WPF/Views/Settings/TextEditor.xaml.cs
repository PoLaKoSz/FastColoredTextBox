using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Views.Settings
{
    public partial class TextEditor : UserControl
    {
        public TextEditor(Models.Settings settings)
		{
			DataContext = settings;

			InitializeComponent();
        }
    }
}

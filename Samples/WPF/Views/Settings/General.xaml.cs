using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Views.Settings
{
	public partial class General : UserControl
    {
        public General(Models.Settings settings)
        {
			DataContext = settings;

            InitializeComponent();
        }
	}
}

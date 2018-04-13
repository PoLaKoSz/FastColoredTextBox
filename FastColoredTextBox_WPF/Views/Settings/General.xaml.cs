using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Views.Settings
{
	/// <summary>
	/// Interaction logic for General.xaml
	/// </summary>
	public partial class General : UserControl
    {
        public General(Models.Settings settings)
        {
			DataContext = settings;

            InitializeComponent();
        }
	}
}

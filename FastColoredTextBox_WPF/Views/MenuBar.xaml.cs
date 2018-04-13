using System.Windows;
using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Views
{
	/// <summary>
	/// Interaction logic for MenuBar.xaml
	/// </summary>
	public partial class MenuBar : UserControl
	{
		public MenuBar()
		{
			InitializeComponent();
		}
		
		private void SettingsMenuButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.SettingsViewModel.OpenSettingsWindow();
		}
	}
}

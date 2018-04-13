using FastColoredTextBox_WPF.ViewModels;
using System.Windows;

namespace FastColoredTextBox_WPF.Views.Settings
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		public SettingsWindow(SettingsViewModel viewModel)
		{
			DataContext = viewModel;

			InitializeComponent();
		}
	}
}

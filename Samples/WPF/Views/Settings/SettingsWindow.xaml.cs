using FastColoredTextBox_WPF.ViewModels;
using System.Windows;

namespace FastColoredTextBox_WPF.Views.Settings
{
	public partial class SettingsWindow : Window
	{
		public SettingsWindow(SettingsViewModel viewModel)
		{
			DataContext = viewModel;

			InitializeComponent();
		}
	}
}

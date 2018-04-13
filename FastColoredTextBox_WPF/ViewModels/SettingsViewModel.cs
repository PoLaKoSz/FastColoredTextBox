using FastColoredTextBox_WPF.Helpers;
using FastColoredTextBox_WPF.Models;
using FastColoredTextBox_WPF.Models.SettingsModels;
using FastColoredTextBox_WPF.Views.Settings;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastColoredTextBox_WPF.ViewModels
{
	public class SettingsViewModel
	{
		private SettingsWindow View { get; set; }

		public Settings CurrentSettings { get; private set; }

		public SettingsMenu[] MenuItems { get; private set; }
		public SettingsMenu CurrentMenu { get; private set; }

		public ICommand ChangeSubmenuViewCommand
		{
			get
			{
				return new CommandHandler(param => SettingsSubmenu_Click(param as SettingsMenu), true);
			}
		}



		public SettingsViewModel(Settings settings)
		{
			CurrentSettings = settings;

			MenuItems = new SettingsMenuCollection(CurrentSettings).MenuItems;

			CurrentMenu = MenuItems[0];

			View = new SettingsWindow(this);
		}



		public void OpenSettingsWindow()
		{
			View.Show();

			ChangeSubmenuView(CurrentMenu.View);
		}

		private void ChangeSubmenuView(UserControl userControl)
		{
			View.settingsSubViewContainer.Children.Clear();

			View.settingsSubViewContainer.Children.Add(userControl);
		}

		private void SettingsSubmenu_Click(SettingsMenu newSettingsSubmenu)
		{
			ChangeSubmenuView(newSettingsSubmenu.View);
		}
	}
}

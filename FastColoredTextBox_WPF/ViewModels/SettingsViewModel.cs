using FastColoredTextBox_WPF.MVMM;
using FastColoredTextBox_WPF.Models;
using FastColoredTextBox_WPF.Models.SettingsModels;
using FastColoredTextBox_WPF.Views.Settings;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastColoredTextBox_WPF.ViewModels
{
	public class SettingsViewModel
	{
        private readonly SettingsWindow _view;


		public Settings CurrentSettings { get; private set; }

        public SettingsMenu[] MenuItems { get; private set; }
		public SettingsMenu CurrentMenu { get; private set; }

		public ICommand ChangeSubmenuViewCommand
		{
			get => new CommandHandler(param => SettingsSubmenu_Click(param as SettingsMenu), true);
		}



        public SettingsViewModel(Settings settings)
		{
			CurrentSettings = settings;

			MenuItems = new SettingsMenuCollection(CurrentSettings).MenuItems;

			CurrentMenu = MenuItems[0];

			_view = new SettingsWindow(this);
		}



        public void OpenView()
        {
            _view.Show();

            ChangeSubmenuView(CurrentMenu.View);
        }

		private void ChangeSubmenuView(UserControl userControl)
		{
			_view.settingsSubViewContainer.Children.Clear();

			_view.settingsSubViewContainer.Children.Add(userControl);
		}

		private void SettingsSubmenu_Click(SettingsMenu newSettingsSubmenu)
		{
			ChangeSubmenuView(newSettingsSubmenu.View);
		}
	}
}

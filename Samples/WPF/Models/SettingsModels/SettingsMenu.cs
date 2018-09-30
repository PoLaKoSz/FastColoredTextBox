using System.Windows.Controls;

namespace FastColoredTextBox_WPF.Models.SettingsModels
{
	public class SettingsMenu
	{
		public string Name { get; protected set; }
		public UserControl View { get; set; }



		public SettingsMenu(string menuName, UserControl userControl)
		{
			Name = menuName;
			View = userControl;
		}
	}
}

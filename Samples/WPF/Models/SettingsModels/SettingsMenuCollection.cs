using FastColoredTextBox_WPF.Languages;
using FastColoredTextBox_WPF.Views.Settings;

namespace FastColoredTextBox_WPF.Models.SettingsModels
{
	public class SettingsMenuCollection
	{
		public SettingsMenu[] MenuItems { get; private set; }



		public SettingsMenuCollection(Settings settings)
		{
			MenuItems = new SettingsMenu[]
			{
				new SettingsMenu(Resources.settings_submenu_general,    new General(settings)),
				new SettingsMenu(Resources.settings_submenu_textEditor, new TextEditor(settings)),
			};
		}
	}
}

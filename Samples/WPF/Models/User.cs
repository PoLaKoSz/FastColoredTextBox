using FastColoredTextBoxNS;

namespace FastColoredTextBox_WPF.Models
{
	public class User
	{
		public Settings Settings { get; protected set; }



		public User(FastColoredTextBox fctbSettings)
		{
			Settings = new Settings(fctbSettings);
		}
	}
}

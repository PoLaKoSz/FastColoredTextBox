using FastColoredTextBox_WPF.Models;
using FastColoredTextBoxNS;

namespace FastColoredTextBox_WPF.ViewModels
{
	public class UserViewModel
	{
		public User CurrentUser { get; private set; }



		public UserViewModel(FastColoredTextBox fctb)
		{
			CurrentUser = new User(fctb);
		}
	}
}

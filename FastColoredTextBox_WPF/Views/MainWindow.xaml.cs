using FastColoredTextBox_WPF.ViewModels;
using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Models.Syntaxes;
using System.Windows;
using System.Windows.Forms.Integration;

namespace FastColoredTextBox_WPF
{
	public partial class MainWindow : Window
	{
		public UserViewModel UserViewModel { get; private set; }
		public static SettingsViewModel SettingsViewModel { get; private set; }
		private FastColoredTextBox FCTB { get; set; }



		public MainWindow()
		{
			// Change the app UI language
			//System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hu");

			FCTB = new FastColoredTextBox
			{
				Language = new LuaSyntax()
			};

			UserViewModel = new UserViewModel(FCTB);

			SettingsViewModel = new SettingsViewModel(UserViewModel.CurrentUser.Settings);

			InitializeComponent();
		}



		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			var windowsFormHost = new WindowsFormsHost
			{
				Child = FCTB
			};

			FastColoredTextBoxContainer.Children.Add(windowsFormHost);
		}
	}
}

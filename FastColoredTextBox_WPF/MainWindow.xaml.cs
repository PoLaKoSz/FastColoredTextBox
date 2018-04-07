using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Models.Syntaxes;
using System.Windows;
using System.Windows.Forms.Integration;

namespace FastColoredTextBox_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Create the interop host control.
			var host = new WindowsFormsHost();

			// Create the FastColoredTextBox control.
			var fctb = new FastColoredTextBox
			{
				Language = new CSharpSyntax()
			};

			// Assign the FastColoredTextBox control as the host control's child.
			host.Child = fctb;

			// Add the interop host control to the Grid
			// control's collection of child controls.
			this.ColoredTextBoxTutorial.Children.Add(host);
		}
	}
}

using FastColoredTextBox_WPF.ViewModels;
using System;
using System.Windows;

namespace FastColoredTextBox_WPF
{
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new MainViewModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The application exit with this error: \n" + ex.ToString());
                Current.Shutdown();
            }
        }
    }
}

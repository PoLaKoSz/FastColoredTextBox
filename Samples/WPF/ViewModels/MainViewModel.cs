using FastColoredTextBox_WPF.Models;
using FastColoredTextBox_WPF.Modules;
using FastColoredTextBoxNS;
using FastColoredTextBoxNS.Models.Syntaxes;
using System.Windows;

namespace FastColoredTextBox_WPF.ViewModels
{
    public class MainViewModel
    {
        private readonly Window _view;


        public MenuBar MenuBar { get; }



        public MainViewModel()
        {
            var IDE = new FastColoredTextBox
            {
                Language = new LuaSyntax()
            };

            var settings = new SettingsViewModel(new Settings(IDE));

            IFileBroker fileBroker = new FileBroker();

            MenuBar = new MenuBar(settings, IDE, fileBroker);

            _view = new MainWindow(this, IDE);
            _view.Show();
        }
    }
}

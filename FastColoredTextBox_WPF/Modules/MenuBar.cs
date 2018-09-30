using FastColoredTextBox_WPF.MVMM;
using FastColoredTextBox_WPF.ViewModels;
using FastColoredTextBoxNS;
using System.Windows.Input;

namespace FastColoredTextBox_WPF.Modules
{
    public class MenuBar
    {
        private readonly SettingsViewModel _settings;
        private readonly FastColoredTextBox _ide;
        private readonly Exporter _exporter;


        public ICommand OpenSettingsCommand { get => new CommandHandler(p => _settings.OpenView(), true); }
        public ICommand ExportToHtmlCommand { get => new CommandHandler(p => _exporter.ToHTML(_ide), true); }
        public ICommand ExportToRtfCommand { get => new CommandHandler(p => _exporter.ToRTF(_ide), true); }



        public MenuBar(SettingsViewModel settings, FastColoredTextBox ide)
        {
            _settings = settings;
            _ide = ide;
            _exporter = new Exporter();
        }
    }
}

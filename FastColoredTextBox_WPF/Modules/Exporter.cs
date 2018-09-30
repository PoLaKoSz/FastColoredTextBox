using FastColoredTextBoxNS;
using System.Windows.Forms;

namespace FastColoredTextBox_WPF.Modules
{
    public class Exporter
    {
        private readonly ExportToHTML _html;
        private readonly ExportToRTF _rtf;
        private readonly SaveFileDialog _dialog;



        public Exporter()
            : this(new ExportToHTML(), new ExportToRTF(), new SaveFileDialog()) { }
        public Exporter(ExportToHTML html, ExportToRTF rtf, SaveFileDialog saveFileDialog)
        {
            _html = html;
            _rtf = rtf;
            _dialog = saveFileDialog;
        }



        public string ToHTML(FastColoredTextBox source)
        {
            ShowDialog();
            return "<pre>" + _html.GetHtml(source) + "</pre>";
        }

        public string ToRTF(FastColoredTextBox source)
        {
            return _rtf.GetRtf(source);
        }

        private void ShowDialog()
        {
            _dialog.ShowDialog();
        }
    }
}

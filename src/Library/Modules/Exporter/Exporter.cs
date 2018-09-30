using System;

namespace FastColoredTextBoxNS
{
    public class Exporter
    {
        private readonly IFileBroker _fileBroker;
        private readonly ExportToHTML _html;
        private readonly ExportToRTF _rtf;



        public Exporter(IFileBroker fileBroker)
            : this(new ExportToHTML(), new ExportToRTF(), fileBroker) { }
        public Exporter(ExportToHTML html, ExportToRTF rtf, IFileBroker fileBroker)
        {
            _html = html;
            _rtf = rtf;
            _fileBroker = fileBroker;
        }



        public void ToHTML(FastColoredTextBox source)
        {
            ToHTML(_html, source);
        }

        public void ToHTML(ExportToHTML output, FastColoredTextBox source)
        {
            _fileBroker.SaveWithDialog(new HtmlFileType(), output.GetHtml(source));
        }

        public void ToRTF(FastColoredTextBox source)
        {
            ToRTF(_rtf, source);
        }

        public void ToRTF(ExportToRTF output, FastColoredTextBox source)
        {
            _fileBroker.SaveWithDialog(new RtfFileType(), output.GetRtf(source));
        }
    }
}

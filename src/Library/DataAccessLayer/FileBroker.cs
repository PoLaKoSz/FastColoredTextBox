using System.IO;
using System.Windows.Forms;

namespace FastColoredTextBoxNS
{
    public class FileBroker : IFileBroker
    {
        private readonly SaveFileDialog _dialog;



        public FileBroker()
        {
            _dialog = new SaveFileDialog();
        }



        public void SaveWithDialog(IFileType fileType, string content)
        {
            _dialog.Filter = fileType.FilterPattern;

            if (_dialog.ShowDialog() == DialogResult.OK)
            {
                WriteToFile(_dialog.FileName, content);
            }

            _dialog.Reset();
        }

        private void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}

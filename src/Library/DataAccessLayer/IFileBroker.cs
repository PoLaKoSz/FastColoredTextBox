using System;

namespace FastColoredTextBoxNS
{
    public interface IFileBroker
    {
        void SaveWithDialog(IFileType fileType, string content);
    }
}

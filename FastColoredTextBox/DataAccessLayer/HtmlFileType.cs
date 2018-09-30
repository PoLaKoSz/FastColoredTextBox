using System;

namespace FastColoredTextBoxNS
{
    public class HtmlFileType : IFileType
    {
        public string FilterPattern { get; }



        public HtmlFileType()
        {
            FilterPattern = "HTML file|*.html";
        }
    }
}

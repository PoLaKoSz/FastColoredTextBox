using System;

namespace FastColoredTextBoxNS
{
    public class RtfFileType : IFileType
    {
        public string FilterPattern { get; }



        public RtfFileType()
        {
            FilterPattern = "RTF file|*.rtf";
        }
    }
}

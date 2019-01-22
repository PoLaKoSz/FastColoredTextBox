using System.Collections.Generic;
using System.Windows.Forms;

namespace FastColoredTextBoxNS.Modules
{
    public interface IModule
    {
        void OnPaint(int lineIndex, PaintEventArgs e, LineInfo lineInfo);

        void LineInserted(int index, int count);

        void LineRemoved(int index, int count, List<int> removedLineIds);
    }
}

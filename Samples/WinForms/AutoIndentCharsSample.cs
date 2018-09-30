using FastColoredTextBoxNS.Models.Syntaxes;
using System.Windows.Forms;

namespace Tester
{
    public partial class AutoIndentCharsSample : Form
    {
        public AutoIndentCharsSample()
        {
            InitializeComponent();
			fctb.Language = new LuaSyntax();
        }
    }
}

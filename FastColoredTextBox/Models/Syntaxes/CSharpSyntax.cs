using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class CSharpSyntax : Syntax
    {
        public BracketsHighlightStrategy BracketsHighlightStrategy { get; protected set; }



        public CSharpSyntax()
			: base("C#")
        {
            CommentPrefix = "//";
            LeftBracket = '(';
            RightBracket = ')';
            LeftBracket2 = '{';
            RightBracket2 = '}';

            BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;
        }

        public override void AutoIndentNeeded(AutoIndentEventArgs args)
        {
            //end of block
            if (Regex.IsMatch(args.LineText, @"^\s*(end|until)\b"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            // then ...
            if (Regex.IsMatch(args.LineText, @"\b(then)\s*\S+"))
                return;
            //start of operator block
            if (Regex.IsMatch(args.LineText, @"^\s*(function|do|for|while|repeat|if)\b"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //Statements else, elseif, case etc
            if (Regex.IsMatch(args.LineText, @"^\s*(else|elseif)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                return;
            }
        }
    }
}

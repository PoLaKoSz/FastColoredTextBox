using System;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class CustomSyntax : Syntax
    {
        public BracketsHighlightStrategy BracketsHighlightStrategy { get; }



        public CustomSyntax()
			: base("Custom")
        {
			BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy1;
        }
    }
}

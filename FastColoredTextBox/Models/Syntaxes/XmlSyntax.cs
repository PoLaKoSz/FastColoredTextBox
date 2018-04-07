using System.Collections.Generic;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
	public class XmlSyntax : ILanguage
	{
		public List<Rule> Rules { get; protected set; }

		public string Name { get; protected set; }

		public string CommentPrefix { get; protected set; }

		public char LeftBracket { get; set; }
		public char RightBracket { get; set; }

		public char LeftBracket2 { get; set; }
		public char RightBracket2 { get; set; }

		public BracketsHighlightStrategy BracketsHighlightStrategy { get; protected set; }

		public string AutoIndentCharsPatterns { get; protected set; }

		public List<Marker> FoldingMarkers { get; protected set; }


		public XmlSyntax()
		{
			Name = "XML";

			Rules = new List<Rule>();

			CommentPrefix = "//";
			LeftBracket = Bracket.Disabled;
			RightBracket = Bracket.Disabled;
			LeftBracket2 = Bracket.Disabled;
			RightBracket2 = Bracket.Disabled;

			BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

			AutoIndentCharsPatterns = "";

			FoldingMarkers = new List<Marker>();
		}


		public void AutoIndentNeeded(AutoIndentEventArgs args)
		{
			
		}

		public Style[] GetStyles()
		{
			var styles = new Style[Rules.Count];

			for (int i = 0; i < styles.Length; i++)
				styles[i] = Rules[i].Style;

			return styles;
		}
	}
}

﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
    public class CSharpSyntax : ILanguage
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



        public CSharpSyntax()
        {
			Name = "C#";

            Rules = new List<Rule>();

            CommentPrefix = "//";
            LeftBracket = '(';
            RightBracket = ')';
            LeftBracket2 = '{';
            RightBracket2 = '}';

            BracketsHighlightStrategy = BracketsHighlightStrategy.Strategy2;

            AutoIndentCharsPatterns = "";

            FoldingMarkers = new List<Marker>();
        }

        public void AutoIndentNeeded(AutoIndentEventArgs args)
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

        public Style[] GetStyles()
        {
            var styles = new Style[Rules.Count];

            for (int i = 0; i < styles.Length; i++)
                styles[i] = Rules[i].Style;

            return styles;
        }
    }
}
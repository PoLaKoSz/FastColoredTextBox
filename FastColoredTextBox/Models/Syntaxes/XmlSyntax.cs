﻿using System.Collections.Generic;

namespace FastColoredTextBoxNS.Models.Syntaxes
{
	public class XmlSyntax : Syntax
	{
		public XmlSyntax()
			: base("XML")
		{
			CommentPrefix = "//";
		}
	}
}

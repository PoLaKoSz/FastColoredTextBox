﻿//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pavel_torgashov@ukr.net
//
//  Copyright (C) Pavel Torgashov, 2011-2016. 

// #define debug


// -------------------------------------------------------------------------------
// By default the FastColoredTextbox supports no more 16 styles at the same time.
// This restriction saves memory.
// However, you can to compile FCTB with 32 styles supporting.
// Uncomment following definition if you need 32 styles instead of 16:
//
// #define Styles32

using System;

namespace FastColoredTextBoxNS
{
	public class AutoIndentEventArgs : EventArgs
    {
		public int iLine { get; internal set; }
		public int TabLength { get; internal set; }
		public string LineText { get; internal set; }
		public string PrevLineText { get; internal set; }

		/// <summary>
		/// Additional spaces count for this line, relative to previous line
		/// </summary>
		public int Shift { get; set; }

		/// <summary>
		/// Additional spaces count for next line, relative to previous line
		/// </summary>
		public int ShiftNextLines { get; set; }

		/// <summary>
		/// Absolute indentation of current line. You can change this property if you want to set absolute indentation.
		/// </summary>
		public int AbsoluteIndentation { get; set; }


		
		public AutoIndentEventArgs(int iLine, string lineText, string prevLineText, int tabLength, int currentIndentation)
        {
            this.iLine = iLine;
            LineText = lineText;
            PrevLineText = prevLineText;
            TabLength = tabLength;
            AbsoluteIndentation = currentIndentation;
        }
    }
}

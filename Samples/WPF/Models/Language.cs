using System;

namespace FastColoredTextBox_WPF.Models
{
	public class Language
	{
		public string CultureName { get; protected set; }
		public string DisplayName { get; protected set; }



		public Language(string cultureName, string displayName)
		{
			CultureName = cultureName;
			DisplayName = displayName;
		}
	}
}
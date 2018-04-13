using System.Collections.Generic;

namespace FastColoredTextBox_WPF.Models
{
	public class SupportedLanguageCollection
	{
		public List<Language> SupportedLanguages { get; protected set; }



		public SupportedLanguageCollection()
		{
			SupportedLanguages = new List<Language>()
			{
				new Language("en",    "English (international)"),
				new Language("hu-HU", "Magyar"),
			};
		}
	}
}

using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Globalization;

namespace FastColoredTextBox_WPF.Models
{
	public class Settings
	{
		public FastColoredTextBox TextEditorSettings { get; protected set; }

		public List<Language> SupportedLanguages { get; protected set; }
		private Language _currentLanguage;
		public Language CurrentLanguage
		{
			get { return _currentLanguage; }
			set
			{
				_currentLanguage = value;

				if (value == null)
					return;

				CultureInfo.CurrentCulture = new CultureInfo(value.CultureName);
			}
		}
		public bool IsRestartNeededVisible { get; set; }

		private bool _isDisplayLineNumber;
		public bool IsDisplayLineNumber
		{
			get { return _isDisplayLineNumber; }
			set
			{
				_isDisplayLineNumber = value;

				TextEditorSettings.ShowLineNumbers = value;
			}
		}



		public Settings(FastColoredTextBox fctbSettings)
		{
			TextEditorSettings = fctbSettings;

			SupportedLanguages = new SupportedLanguageCollection().SupportedLanguages;

			var currentCulture = CultureInfo.CurrentCulture;
			CurrentLanguage = SupportedLanguages
				.Find(l => l.CultureName.Equals(currentCulture.DisplayName));
			if (CurrentLanguage == null)
				CurrentLanguage = SupportedLanguages[0];

			IsRestartNeededVisible = false;

			IsDisplayLineNumber = true;
		}
	}
}

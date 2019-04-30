using System;
using EPiServer.Core;
using EPiServer.Globalization;

namespace AlloyTemplates.Business.Initialization
{
    public class CustomUpdateCurrentLanguage : IUpdateCurrentLanguage
    {
        private readonly IUpdateCurrentLanguage _existingClass;

        public CustomUpdateCurrentLanguage(IUpdateCurrentLanguage existingClass)
        {
            _existingClass = existingClass;
        }

        public void UpdateLanguage(string languageId)
        {
            var currentPreferredLanguage = ContentLanguage.PreferredCulture;
            _existingClass.UpdateLanguage(languageId);

            var newLanguage = ContentLanguage.PreferredCulture;

            if (languageId == null && currentPreferredLanguage.Name != newLanguage.Name)
            {
                throw new Exception($"ContentLanguage.PreferredCulture was set to '{currentPreferredLanguage.Name}' but routing set the language to null, which in turn changed language to '{newLanguage.Name}'. It doesn't matter that {currentPreferredLanguage.Name} doesn't exist in enabled languages, had it existed the code for calculating new language from null don't take the current value into account.");
            }

        }

        public void UpdateReplacementLanguage(IContent currentContent, string requestedLanguage)
        {
            _existingClass.UpdateReplacementLanguage(currentContent, requestedLanguage);
        }
    }
}

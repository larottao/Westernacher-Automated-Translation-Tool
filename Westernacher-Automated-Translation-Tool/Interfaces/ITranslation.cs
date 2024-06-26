using System;

namespace Automated_Office_Translation_Tool.Interfaces
{
    internal interface ITranslation
    {
        Boolean checkIfBrowserIsOpen();

        Boolean openBrowser();

        Boolean goToProviderSite();

        Boolean setTranslationLanguages(String sourceLang, String destLang);

        Tuple<Boolean, String> translate(String originalText);

        Boolean closeBrowser();
    }
}
using System;

namespace Automated_Office_Translation_Tool.Models
{
    public class LocalTranslationQuery
    {
        public String SourceLanguage { get; set; }
        public String TargetLanguage { get; set; }
        public string OriginalText { get; set; }

        public LocalTranslationQuery(String SourceLanguage, String TargetLanguage, String OriginalText)
        {
            this.SourceLanguage = SourceLanguage;
            this.TargetLanguage = TargetLanguage;
            this.OriginalText = OriginalText;
        }
    }
}
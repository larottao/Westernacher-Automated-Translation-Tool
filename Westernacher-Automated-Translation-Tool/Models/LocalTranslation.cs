using System;

namespace Automated_Office_Translation_Tool.Models
{
    public class LocalTranslation
    {
        public String SourceLanguage { get; set; }
        public String TargetLanguage { get; set; }
        public string OriginalText { get; set; }
        public string ChangedText { get; set; }
    }
}
using System;

namespace Automated_Office_Translation_Tool.Models
{
    public class TranslationConfiguration
    {
        public String originalLanguage { get; set; }
        public String targetLanguage { get; set; }
        public String apiUrl { get; set; }
        public String apiKey { get; set; }
    }
}
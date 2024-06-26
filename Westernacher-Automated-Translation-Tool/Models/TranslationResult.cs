using System;

namespace Automated_Office_Translation_Tool.Models
{
    public class TranslationResult
    {
        public Boolean translationWasSuccess { get; set; }
        public String failureReason { get; set; }
        public String originalText { get; set; }
        public String translatedText { get; set; }
    }
}
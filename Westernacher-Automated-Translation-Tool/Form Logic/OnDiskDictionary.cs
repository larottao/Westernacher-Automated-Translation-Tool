using Automated_Office_Translation_Tool.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Automated_Office_Translation_Tool.GlobalConstants;

namespace Automated_Office_Translation_Tool.Services
{
    public class OnDiskDictionary
    {
        private string filePath;

        private Dictionary<string, LocalTranslation> translationDictionary;

        public OnDiskDictionary()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SAVED_TRANSLATIONS_FILE);
            translationDictionary = LoadTranslations();
        }

        private string CreateKey(String sourceLanguage, String targetLanguage, string originalText)
        {
            return $"{sourceLanguage}|{targetLanguage}|{originalText}";
        }

        public void SaveToDictionary(LocalTranslation localTranslation)
        {
            string key = CreateKey(localTranslation.SourceLanguage, localTranslation.TargetLanguage, localTranslation.OriginalText);
            translationDictionary[key] = localTranslation;
            SaveTranslations(translationDictionary);
        }

        public Tuple<bool, string> ReadFromDictionary(LocalTranslationQuery localTranslationQuery)
        {
            if (translationDictionary.Count == 0)
            {
                translationDictionary = LoadTranslations();
            }

            string key = CreateKey(localTranslationQuery.SourceLanguage, localTranslationQuery.TargetLanguage, localTranslationQuery.OriginalText);

            if (translationDictionary.TryGetValue(key, out LocalTranslation translation))
            {
                return Tuple.Create(true, translation.ChangedText);
            }

            return Tuple.Create(false, "");
        }

        private Dictionary<string, LocalTranslation> LoadTranslations()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var translations = JsonSerializer.Deserialize<List<LocalTranslation>>(json);
                var dict = new Dictionary<string, LocalTranslation>();
                foreach (var translation in translations)
                {
                    var key = CreateKey(Convert.ToString(translation.SourceLanguage), translation.TargetLanguage, translation.OriginalText);
                    dict[key] = translation;
                }
                return dict;
            }
            return new Dictionary<string, LocalTranslation>();
        }

        private void SaveTranslations(Dictionary<string, LocalTranslation> translations)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(translations.Values, options);
            File.WriteAllText(filePath, json);
        }
    }
}
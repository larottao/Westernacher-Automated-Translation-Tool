using Automated_Office_Translation_Tool.Interfaces;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using static Automated_Office_Translation_Tool.GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automated_Office_Translation_Tool.Services.Translation
{
    public class TranslateWithDeepLAPI : ITranslation
    {
        public bool setTranslationLanguages(string sourceLang, string destLang)
        {
            GlobalVariables.globalSourceLanguage = sourceLang.ToUpper();
            GlobalVariables.globalDestinationLanguage = destLang.ToUpper();

            return true;
        }

        public Tuple<bool, string> translate(string originalText)

        {
            if (String.IsNullOrEmpty(GlobalVariables.deepLUrl))
            {
                return new Tuple<bool, String>(false, "The DeepL URL is empty. Please set it first.");
            }

            if (String.IsNullOrEmpty(GlobalVariables.deepLAuthKey))
            {
                return new Tuple<bool, String>(false, "The DeepL Auth Key is empty. Please set it first.");
            }

            var client = new RestClient(GlobalVariables.deepLUrl);
            var request = new RestRequest
            {
                Method = Method.Post,
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Authorization", "DeepL-Auth-Key " + deepLAuthKey);
            request.AddHeader("Content-Type", "application/json");

            //DeepL will screw the line jumps. This code fixes it:

            String originalTextWithProperLineJumps = originalText.Replace("\r", "\r\n");   

            var body = new
            {
                text = new[] { originalTextWithProperLineJumps },
                target_lang = globalDestinationLanguage
            };

            request.AddJsonBody(body);

            try
            {
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    var jsonResponse = JObject.Parse(response.Content);
                    var translatedText = jsonResponse["translations"][0]["text"].ToString();
                    return Tuple.Create(true, translatedText);
                }
                else
                {
                    String errorExplanation = "";

                    if (response.StatusDescription != null)
                    {
                        errorExplanation = response.StatusDescription.ToString();
                    }
                    else if (response.ErrorMessage != null)
                    {
                        errorExplanation = response.ErrorMessage.ToString();
                    }

                    return Tuple.Create(false, errorExplanation);
                }
            }
            catch (Exception ex)
            {
                return Tuple.Create(false, ex.Message);
            }
        }

        public bool checkIfBrowserIsOpen()
        {
            throw new NotImplementedException();
        }

        public bool closeBrowser()
        {
            throw new NotImplementedException();
        }

        public bool goToProviderSite()
        {
            throw new NotImplementedException();
        }

        public bool openBrowser()
        {
            throw new NotImplementedException();
        }
    }
}
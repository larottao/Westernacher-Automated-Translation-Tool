using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Automated_Office_Translation_Tool
{
    public class SaveOnDisk
    {
        public void savefiguresListToJson(List<Figure> figuresList, string filename)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented // Optional: for pretty printing
                };
                string json = JsonConvert.SerializeObject(figuresList, settings);
                File.WriteAllText(filename, json);

                Console.WriteLine(DateTime.Now + " Saved on disk.");
            }
            catch (Exception ex)
            {
                //TODO Error handling
            }
        }
    }
}
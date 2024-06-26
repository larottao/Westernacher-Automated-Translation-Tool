using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Automated_Office_Translation_Tool
{
    public class LoadFromDisk
    {
        public Tuple<Boolean, String, List<Figure>> loadfiguresListFromJson(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    string json = File.ReadAllText(filename);

                    List<Figure> figuresListResult = JsonConvert.DeserializeObject<List<Figure>>(json);

                    return new Tuple<Boolean, String, List<Figure>>(true, "", figuresListResult);
                }
                catch (Exception ex)
                {
                    return new Tuple<Boolean, String, List<Figure>>(false, $"ERROR: UNABLE TO LOAD PREVIOUS PROJECT, INCORRECT JSON. {ex.Message}", null);
                }
            }
            return new Tuple<Boolean, String, List<Figure>>(false, "ERROR: UNABLE TO LOAD PREVIOUS PROJECT, FILE DOES NOT EXIST.", null);
        }
    }
}
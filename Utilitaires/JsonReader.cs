using CampusFrance.test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusFrance.test.Utilitaires
{
    public static class JsonReader
    {
        public static List<FormulaireData> LoadFormData(string filePath)

        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<FormulaireData>>(json);
        }

    }
}

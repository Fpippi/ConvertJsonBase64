using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConvertJsonBase64.Utility
{
    internal static class HelperBase64
    {
        public static Dictionary<string, string> DecodeBase64Json(string base64EncodedJson)
        {
            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();

            try
            {
                base64EncodedJson = base64EncodedJson.Replace(" ", "").Replace("\n", "").Replace("\r", "");

                // Verifica la validità della stringa Base64
                if (IsBase64String(base64EncodedJson))
                {
                    byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedJson);
                    string json = Encoding.UTF8.GetString(base64EncodedBytes);

                    var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

                    foreach (var entry in dictionary)
                    {
                        resultDictionary.Add(entry.Key, entry.Value?.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("La stringa non è una stringa Base64 valida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la decodifica del Base64 JSON: {ex}");
            }

            return resultDictionary;
        }

        private static bool IsBase64String(string base64String)
        {
            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }



        public static string ConvertToJsonBase64(string jsonString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
        }



    }
}

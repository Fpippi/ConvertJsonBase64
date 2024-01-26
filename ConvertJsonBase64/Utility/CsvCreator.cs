using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace ConvertJsonBase64.Utility
{
    internal class CsvCreator
    {
        public void CreateCsvFile(Dictionary<string, string> data, string directoryPath, string NameFile = $"TestProva.csv")
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, NameFile);

                using (StreamWriter writer = new StreamWriter(filePath))
                using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(data);
                }

                Console.WriteLine($"File CSV creato con successo: {filePath}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Errore di autorizzazione: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }

        }

    }
}

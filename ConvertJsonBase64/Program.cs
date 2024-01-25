using ConvertJsonBase64.Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class StartUp()
{
    public static void Main()
    {


        ////principale
        //var Base64json1 = "ew0KICAibm9tZSI6ICJKb2huIERvZSIsDQogICJldMOgIjogMTgsDQogICJjaXR0w6AiOiAiTmV3IFlvcmsiLA0KICAic3Bvc2F0byI6IGZhbHNlLA0KICAiaG9iYnkiOiAiVGVzdCINCn0=";

        ////secondario
        //var Base64json2 = "ew0KICAiZXTDoCI6IDMwLA0KICAibm9tZSI6ICJNYXJpbyIsDQogICJwdW50ZWdnaW8iOiA0MiwNCiAgImF0dGl2byI6IHRydWUNCn0=";

        //var json1 = HelperBase64.DecodeBase64Json(Base64json1);
        //var json2 = HelperBase64.DecodeBase64Json(Base64json2);

        var jsonTest1 = @"{
                              ""nome"": ""John Doe"",
                              ""età"": 18,
                              ""città"": ""New York"",
                              ""sposato"": false,
                              ""hobby"": ""Test""
                           }";


        var jsonTest2 = @"{
                                   ""età"": 30,
                          ""nome"": ""Mario"",
                          ""punteggio"": 42,
                          ""attivo"": true
                           }";


        var Base64json1 = HelperBase64.ConvertToJsonBase64(jsonTest1);
        var Base64json2 = HelperBase64.ConvertToJsonBase64(jsonTest2);

        var json1 = HelperBase64.DecodeBase64Json(Base64json1);
        var json2 = HelperBase64.DecodeBase64Json(Base64json2);


        var risultato = AggiungiValoriMancanti(json1, json2);
        
        string filePath = @"C:\\Progetti\\Test\Prova";

         
        CsvCreator csvCreator = new CsvCreator();

        // Crea il file CSV
        if(risultato.Count() != 0)
        {
            csvCreator.CreateCsvFile(risultato, filePath);
        }
    }

    static Dictionary<string, string>  AggiungiValoriMancanti(Dictionary<string, string> dizionarioA, Dictionary<string, string> dizionarioB)
    {
        foreach (var coppiaB in dizionarioB)
        {
            if (!dizionarioA.ContainsKey(coppiaB.Key))
            {
                dizionarioA.Add(coppiaB.Key, coppiaB.Value);
            }
        }

        return dizionarioA;
    }
}


/*
 
{
  "nome": "John Doe",
  "età": 18,
  "città": "New York",
  "sposato": false,
  "hobby": "Test"
}


{
  "età": 30,
  "nome": "Mario",
  "punteggio": 42,
  "attivo": true
}

 */
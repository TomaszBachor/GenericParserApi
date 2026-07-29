using GenericParserApi.Models;
using System.Text.Json;

namespace GenericParserApi.Parsers
{
    public class JsonParser : IJsonParser
    {
        // Parsuje dane JSON do ujednoliconej struktury.
        public List<ParsedRecord> Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("JSON jest pusty.");
            }
            List<ParsedRecord> result = new();

            // Deserializacja danych JSON do listy słowników.
            var jsonObjects = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(json);

            // Sprawdzenie poprawności zdeserializowanych danych.
            if (jsonObjects == null)
            {
                throw new ArgumentException("Niepoprawny format JSON.");
            }

            foreach (var item in jsonObjects)
            {
                ParsedRecord record = new();
                foreach (var pair in item)
                {
                    record.Values.Add(pair.Key, pair.Value.ToString());
                }
                result.Add(record);
            }

            return result;
        }
    }
}

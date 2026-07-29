using GenericParserApi.Models;

namespace GenericParserApi.Parsers
{
    public class CsvParser : ICsvParser
    {
        // Parsuje dane CSV do ujednoliconej struktury.
        public List<ParsedRecord> Parse(string csv)
        {
            if (string.IsNullOrWhiteSpace(csv))
            {
                throw new ArgumentException("CSV jest pusty.");
            }

            List<ParsedRecord> result = new();
            // Podział pliku CSV na poszczególne wiersze.
            string[] lines = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            // Odczyt nagłówków z pierwszego wiersza.
            string[] headers = lines[0].Trim().Split(',');

            

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Trim().Split(',');

                // Sprawdzenie zgodności liczby nagłówków i wartości.
                if (headers.Length != values.Length)
                {
                    throw new ArgumentException("Niepoprawny format CSV.");
                }

                ParsedRecord record = new();
                for (int j = 0; j < values.Length; j++)
                {
                    // Dodanie par klucz-wartość do rekordu.
                    record.Values.Add(headers[j], values[j]);
                }
                result.Add(record);
            }
            
            return result;
        }
    }
}

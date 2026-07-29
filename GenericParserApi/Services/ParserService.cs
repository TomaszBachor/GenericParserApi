using GenericParserApi.DTO;
using GenericParserApi.Models;
using GenericParserApi.Parsers;
using System.Text;

namespace GenericParserApi.Services
{
    public class ParserService : IParserService
    {
        // Wstrzykiwanie zależności (Dependency Injection)
        private readonly ICsvParser _csvParser;
        private readonly IJsonParser _jsonParser;
        public ParserService(ICsvParser csvParser, IJsonParser jsonParser)
        {
            _csvParser = csvParser;
            _jsonParser = jsonParser;
        }

        public ParseResponseDto Parse(ParseRequestDto request) 
        {
            // Sprawdzenie, czy użytkownik przesłał zawartość do przetworzenia.
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                throw new ArgumentException("Content nie może być pusty.");
            }

            // Dekodowanie danych z formatu Base64.
            string decodedContent;
            try
            {
                decodedContent = Encoding.UTF8.GetString(Convert.FromBase64String(request.Content));
            }
            catch (FormatException)
            {
                throw new ArgumentException("Niepoprawny format Base64.");
            }

            object parsedData;
            int count = 0;

            // Wybór odpowiedniego parsera na podstawie typu danych.
            switch (request.Type)
            {
                case ContentType.CSV:
                    var records_c = _csvParser.Parse(decodedContent);
                    parsedData = records_c;
                    count = records_c.Count;
                    break;
                case ContentType.INTERNAL_JSON:
                    var records_j = _jsonParser.Parse(decodedContent);
                    parsedData = records_j;
                    count = records_j.Count;
                    break;
                default:
                    throw new ArgumentException("Nieobsługiwany typ danych");
            }

            return new ParseResponseDto
            {
                Status = "Success",
                Count = count,
                Date = DateTime.UtcNow,
                Data = parsedData
            };
        }
    }
}

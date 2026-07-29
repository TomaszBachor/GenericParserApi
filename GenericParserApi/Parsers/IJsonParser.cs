using GenericParserApi.Models;

namespace GenericParserApi.Parsers
{
    public interface IJsonParser
    {
        List<ParsedRecord> Parse(string json);
    }
}

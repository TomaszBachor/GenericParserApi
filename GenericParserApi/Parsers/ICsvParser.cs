using GenericParserApi.Models;

namespace GenericParserApi.Parsers
{
    public interface ICsvParser
    {
        List<ParsedRecord> Parse(string csv);
    }
}

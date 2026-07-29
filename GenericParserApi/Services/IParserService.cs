using GenericParserApi.DTO;

namespace GenericParserApi.Services
{
    public interface IParserService
    {
        ParseResponseDto Parse(ParseRequestDto request);
    }
}

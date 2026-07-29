namespace GenericParserApi.DTO
{
    public class ParseResponseDto
    {
        public string Status { get; set; } = string.Empty;
        public int Count { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public object Data { get; set; } = new();
    }
}

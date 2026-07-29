using GenericParserApi.DTO;
using GenericParserApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericParserApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ParseContentController : ControllerBase
    {
        // Wstrzykiwanie zależności (Dependency Injection)
        private readonly IParserService _parserService;
        public ParseContentController(IParserService parserService)
        {
            _parserService = parserService;
        }

        // Obsługa żądania przesłania danych do parsera.
        [HttpPost("parse-content")]
        public IActionResult Index([FromBody] ParseRequestDto request)
        {
            try
            {
                var response = _parserService.Parse(request);
                // Zwrócenie wyniku parsowania.
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                // Zwrócenie błędu walidacji użytkownikowi.
                return BadRequest(ex.Message);
            }
            
        }
    }
}

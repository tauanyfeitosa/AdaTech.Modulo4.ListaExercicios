using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 4")]
internal class WordCounterController : ControllerBase
{
    private readonly WordCounterService _wordCounterService;

    internal WordCounterController(WordCounterService wordCounterService)
    {
        _wordCounterService = wordCounterService;
    }

    [HttpPost("Dicionário")]
    internal ActionResult<Dictionary<string, int>> CountWords([FromBody] string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return BadRequest("O texto de entrada não pode ser nulo ou vazio.");
        }

        var wordCount = _wordCounterService.CountWords(input);
        return Ok(wordCount);
    }
}

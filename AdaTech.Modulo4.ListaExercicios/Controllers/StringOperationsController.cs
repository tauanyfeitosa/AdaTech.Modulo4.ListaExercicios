using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 1")]
public class StringOperationsController : ControllerBase
{
    private readonly StringOperationsService _stringOperationsService;

    public StringOperationsController(StringOperationsService stringOperationsService)
    {
        _stringOperationsService = stringOperationsService;
    }

    [HttpPost("Listas")]
    public ActionResult<List<string>> FilterLongStrings([FromBody] List<string> input)
    {
        return _stringOperationsService.FilterList(input);
    }
}

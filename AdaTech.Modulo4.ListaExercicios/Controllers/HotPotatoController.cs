using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 3")]
internal class HotPotatoController : ControllerBase
{
    private readonly HotPotatoGameService _hotPotatoGameService;

    internal HotPotatoController(HotPotatoGameService hotPotatoGameService)
    {
        _hotPotatoGameService = hotPotatoGameService;
    }

    [HttpPost("Filas - Queue<>")]
    internal ActionResult<string> Play([FromBody] int numberOfPlayers)
    {
        return _hotPotatoGameService.PlayHotPotato(numberOfPlayers);
    }
}

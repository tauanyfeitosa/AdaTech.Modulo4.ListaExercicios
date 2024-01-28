using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 3")]
public class HotPotatoController : ControllerBase
{
    private readonly HotPotatoGameService _hotPotatoGameService;

    public HotPotatoController(HotPotatoGameService hotPotatoGameService)
    {
        _hotPotatoGameService = hotPotatoGameService;
    }

    [HttpPost("Filas - Queue<>")]
    public ActionResult<string> Play([FromBody] int numberOfPlayers)
    {
        return _hotPotatoGameService.PlayHotPotato(numberOfPlayers);
    }
}

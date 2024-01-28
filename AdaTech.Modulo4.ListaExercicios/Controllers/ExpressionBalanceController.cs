using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 2")]
internal class ExpressionBalanceController : ControllerBase
{
    private readonly ExpressionBalanceService _expressionBalanceService;

    internal ExpressionBalanceController(ExpressionBalanceService expressionBalanceService)
    {
        _expressionBalanceService = expressionBalanceService;
    }

    [HttpPost("Pilhas (Stack)")]
    internal ActionResult<bool> CheckBalance([FromBody] string expression)
    {
        return _expressionBalanceService.IsExpressionBalanced(expression);
    }
}

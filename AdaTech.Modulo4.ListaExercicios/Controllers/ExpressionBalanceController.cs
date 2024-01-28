using Microsoft.AspNetCore.Mvc;
using AdaTech.Modulo4.ListaExercicios.Services;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Exercício 2")]
public class ExpressionBalanceController : ControllerBase
{
    private readonly ExpressionBalanceService _expressionBalanceService;

    public ExpressionBalanceController(ExpressionBalanceService expressionBalanceService)
    {
        _expressionBalanceService = expressionBalanceService;
    }

    [HttpPost("Pilhas (Stack)")]
    public ActionResult<bool> CheckBalance([FromBody] string expression)
    {
        return _expressionBalanceService.IsExpressionBalanced(expression);
    }
}

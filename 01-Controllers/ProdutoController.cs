using Microsoft.AspNetCore.Mvc;
using MeowMeowShopAPI.models;
using MeowMeowShopAPI.services.interfaces;

namespace MeowMeowShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{

    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public IActionResult GetProductList()
    {
        return Ok(_produtoService.GetProdutoList());
    }

    [HttpGet("{id}")]
    public IActionResult GetProdutoByID(int id)
    {
        if (id <= 0)
            return BadRequest("Valor deve ser maior que zero");

        var produto = _produtoService.GetProdutoById(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);

    }
}

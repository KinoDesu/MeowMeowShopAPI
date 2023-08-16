using Microsoft.AspNetCore.Mvc;
using MeowMeowShopAPI.services.interfaces;
using System.Data;

namespace MeowMeowShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{

    private readonly IProdutoService _produtoService;
    private readonly IDbConnection _mySqlConnection;

    public ProdutoController(IProdutoService produtoService, IDbConnection mySqlConnection)
    {
        _produtoService = produtoService;
        _mySqlConnection = mySqlConnection;
        
    }

    [HttpGet("ListarProdutos")]
    public async Task<IActionResult> GetProductList()
    {
        return Ok(await _produtoService.GetProdutoList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoByID(int id)
    {
        if (id <= 0)
            return BadRequest("Valor deve ser maior que zero");

        var produto = await _produtoService.GetProdutoById(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);

    }

    [HttpPost]
    public async Task<IActionResult> PostProdutoAsync(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string link)
    {
        var produto = await _produtoService.PostProduto(nome, preco, descricao, quantidade, peso, desconto, link);
        if (produto == null)
        {
            return BadRequest();
        }
        return Ok(produto);
    }
}

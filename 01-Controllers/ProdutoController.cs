using Microsoft.AspNetCore.Mvc;
using MeowMeowShopAPI.models;
using MeowMeowShopAPI.services.interfaces;
using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Logging.Console;
using System.IO;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

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

    [HttpGet("ListarProdutos")]
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

    [HttpPost]
        public async Task<IActionResult> PostProdutoAsync(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string urlImagem)
        {
            var produto = await _produtoService.PostProduto(nome, preco, descricao, quantidade, peso, desconto, urlImagem);
            if(produto==null)
            {
                return BadRequest();
            }
            return Ok(produto);
        }
}

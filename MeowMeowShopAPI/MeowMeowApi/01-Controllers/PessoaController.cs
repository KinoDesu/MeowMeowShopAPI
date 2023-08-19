using MeowMeowShopAPI.MeowMeowApi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;

namespace MeowMeowShopAPI.MeowMeowApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IDbConnection _dbConnection;

        public PessoaController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpPost]
        public async Task<IActionResult> criarCadastro(PessoaModel pessoa)
        {
            var pessoaCriada = await _dbConnection.QueryAsync<PessoaModel>(@$"insert into meowmeowshop.pessoa 
(nome, sobrenome, cpf, email, cep, endereco, complemento, telefone1, telefone2, imagem)
values
(@nome, @sobrenome, @cpf, @email, @cep, @endereco, @complemento, @telefone1, @telefone2, @imagem)"
, new { pessoa.Nome, pessoa.Sobrenome, pessoa.Cpf, pessoa.Email, pessoa.Cep, 
    pessoa.Endereco, pessoa.Complemento, pessoa.Telefone1, pessoa.Telefone2, pessoa.Imagem });

            

            return Ok("Pessoa Criada com sucesso!");

        }
    }
}

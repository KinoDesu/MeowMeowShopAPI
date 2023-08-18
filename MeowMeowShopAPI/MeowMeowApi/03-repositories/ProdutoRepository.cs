using MeowMeowShopAPI.MeowMeowApi.models;
using MeowMeowShopAPI.MeowMeowApi.repositories.interfaces;
using System.Data;
using Dapper;

namespace MeowMeowShopAPI.MeowMeowApi.repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly IDbConnection _dbConnection;

        public ProdutoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ProdutoModel?> GetProdutoById(int id)
        {
            var produtos = await _dbConnection.QueryFirstAsync<ProdutoModel>(@"SELECT * FROM meowmeowshop.produto where id = @id", new { id });

            if (produtos == null)
                return null;

            var imagens = await _dbConnection.QueryAsync<ImageModel>(@$"
                SELECT id AS {nameof(ImageModel.Id)}
                , id_produto AS {nameof(ImageModel.IdProduto)}
                , link AS {nameof(ImageModel.Link)}
                FROM meowmeowshop.imagem_produto where id_produto = @id
            ", new { id });

            produtos.Imagens = new List<ImageModel>() { };
            for (int j = 0; j < imagens.Count(); j++)
            {
                produtos.Imagens.Add(imagens.ElementAt(j));
            }


            return produtos;
        }

        public async Task<List<ProdutoModel>> GetProdutoList()
        {
            var produtos = await _dbConnection.QueryAsync<ProdutoModel>("SELECT * FROM meowmeowshop.produto");
            var imagens = await _dbConnection.QueryAsync<ImageModel>(@$"
                SELECT id AS {nameof(ImageModel.Id)}
                , id_produto AS {nameof(ImageModel.IdProduto)}
                , link AS {nameof(ImageModel.Link)}
                FROM meowmeowshop.imagem_produto
            ");

            for (int i = 0; i < produtos.Count(); i++)
            {
                produtos.ElementAt(i).Imagens = new List<ImageModel>() { };
                for (int j = 0; j < imagens.Count(); j++)
                {
                    if (imagens.ElementAt(j).IdProduto == produtos.ElementAt(i).Id)
                    {
                        produtos.ElementAt(i).Imagens.Add(imagens.ElementAt(j));
                    }
                }
            }

            return produtos.ToList();

        }

        public async Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string link)
        {
            await _dbConnection.QueryAsync<ProdutoModel>(@$"
            INSERT INTO meowmeowshop.produto (nome, preco, descricao, quantidade, desconto) values
            (@nome, @preco, @descricao, @quantidade, @desconto);
            ", new { nome, preco, descricao, quantidade, desconto });

            var produto = await _dbConnection.QueryFirstAsync<ProdutoModel>(@$"select * from meowmeowshop.produto order by id desc");
            int id_produto = produto.Id;

            await _dbConnection.QueryAsync<ImageModel>($@"
            INSERT INTO meowmeowshop.imagem_produto (id_produto, link) values
            (@id_produto, @link)
            ", new { id_produto, link });

            produto = await GetProdutoById(produto.Id);

            return produto;
        }
    }
}
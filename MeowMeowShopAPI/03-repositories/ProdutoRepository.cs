using MeowMeowShopAPI.models;
using MeowMeowShopAPI.repositories.interfaces;
using System.Data;
using Dapper;

namespace MeowMeowShopAPI.repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly IDbConnection _mySqlConnection;

        public ProdutoRepository(IDbConnection mySqlConnection)
        {
            _mySqlConnection = mySqlConnection;
        }

        public async Task<ProdutoModel?> GetProdutoById(int id)
        {
            var produtos = await _mySqlConnection.QueryFirstAsync<ProdutoModel>(@"SELECT * FROM produto where id = @id", new { id } );

            if (produtos == null)
                return null;
            
            var imagens = await _mySqlConnection.QueryAsync<ImageModel>(@$"
                SELECT id AS {nameof(ImageModel.Id)}
                , id_produto AS {nameof(ImageModel.IdProduto)}
                , link AS {nameof(ImageModel.Link)}
                FROM imagem_produto where id_produto = @id
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
            var produtos = await _mySqlConnection.QueryAsync<ProdutoModel>("SELECT * FROM produto");
            var imagens = await _mySqlConnection.QueryAsync<ImageModel>(@$"
                SELECT id AS {nameof(ImageModel.Id)}
                , id_produto AS {nameof(ImageModel.IdProduto)}
                , link AS {nameof(ImageModel.Link)}
                FROM imagem_produto
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
            await _mySqlConnection.QueryAsync<ProdutoModel>(@$"
            INSERT INTO produto (nome, preco, descricao, quantidade, desconto) values
            (@nome, @preco, @descricao, @quantidade, @desconto);
            ", new { nome, preco, descricao, quantidade, desconto });

            var produto = await _mySqlConnection.QueryFirstAsync<ProdutoModel>(@$"select * from produto order by id desc");
            int id_produto = produto.Id;

            await _mySqlConnection.QueryAsync<ImageModel>($@"
            INSERT INTO imagem_produto (id_produto, link) values
            (@id_produto, @link)
            ", new { id_produto, link });

            produto = await GetProdutoById(produto.Id);

            return produto;
        }
    }
}
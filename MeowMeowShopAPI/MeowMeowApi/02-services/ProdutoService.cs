using MeowMeowShopAPI.MeowMeowApi.models;
using MeowMeowShopAPI.MeowMeowApi.repositories.interfaces;
using MeowMeowShopAPI.MeowMeowApi.services.interfaces;

namespace MeowMeowShopAPI.MeowMeowApi.services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<ProdutoModel?> GetProdutoById(int id)
        {
            var produto = await _produtoRepository.GetProdutoById(id);

            return produto;
        }

        public async Task<List<ProdutoModel>> GetProdutoList()
        {
            return await _produtoRepository.GetProdutoList();
        }

        public async Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string link)
        {
            return await _produtoRepository.PostProduto(nome, preco, descricao, quantidade, peso, desconto, link);
        }
    }
}
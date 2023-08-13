using MeowMeowShopAPI.models;
using MeowMeowShopAPI.repositories.interfaces;
using MeowMeowShopAPI.services.interfaces;

namespace MeowMeowShopAPI.services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public ProdutoModel? GetProdutoById(int id)
        {
            var produto = _produtoRepository.GetProdutoById(id);

            return produto;
        }

        public List<ProdutoModel> GetProdutoList()
        {
            return _produtoRepository.GetProdutoList();
        }

        public async Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string urlImagem)
        {
            return await _produtoRepository.PostProduto(nome, preco, descricao, quantidade, peso, desconto, urlImagem);
        }
    }
}
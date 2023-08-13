using MeowMeowShopAPI.models;

namespace MeowMeowShopAPI.repositories.interfaces
{
    public interface IProdutoRepository
    {
        ProdutoModel? GetProdutoById(int id);
        List<ProdutoModel> GetProdutoList();
        Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string urlImagem);
    }
}
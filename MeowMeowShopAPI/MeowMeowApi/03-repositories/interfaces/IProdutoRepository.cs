using MeowMeowShopAPI.MeowMeowApi.models;

namespace MeowMeowShopAPI.MeowMeowApi.repositories.interfaces
{
    public interface IProdutoRepository
    {
        Task<ProdutoModel?> GetProdutoById(int id);
        Task<List<ProdutoModel>> GetProdutoList();
        Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string link);
    }
}
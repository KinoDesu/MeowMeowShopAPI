using MeowMeowShopAPI.models;

namespace MeowMeowShopAPI.services.interfaces
{
    public interface IProdutoService
    {
        ProdutoModel? GetProdutoById(int id);
        List<ProdutoModel> GetProdutoList();

        Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string urlImagem);
    }
}
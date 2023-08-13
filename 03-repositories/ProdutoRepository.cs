using MeowMeowShopAPI.models;
using MeowMeowShopAPI.repositories.interfaces;
using Newtonsoft.Json;

namespace MeowMeowShopAPI.repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private static readonly List<ProdutoModel> _produtos = new()
        {
            new ProdutoModel("colar com correntes e cruz", 55.00, "para quem gosta daquela pegada mais gótica", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("./assets/img/img0 id0.png")}),
            new ProdutoModel("choker de estela", 25.00, "quem aí não adora o estilo y2k???", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("./assets/img/img0 id1.png")}),
            new ProdutoModel("colar com lua", 25.00, "para quem tem uma vibe mais mística e misteriosa", 4, 0.3, 10, new List<ImageModel>(){new ImageModel("./assets/img/img0 id2.png")}),
            new ProdutoModel("colar de pérolas com cruz", 45.00, "um lindo colar de pérolas com uma cruz", 2, 12.4, 50, new List<ImageModel>(){new ImageModel("./assets/img/img0 id3.png")}),
            new ProdutoModel("pulseira de teste", 30.00, "uma pulseira de teste", 2, 12.4, 50, new List<ImageModel>(){new ImageModel("./assets/img/img1 id2.png")})
        };

        public ProdutoRepository()
        {
            var produtos = _produtos;
        }

        public ProdutoModel? GetProdutoById(int id)
        {

            var sr = new StreamReader(@"database\Produtos.json");
            string json = sr.ReadToEnd();
            sr.Close();

            var produto = JsonConvert.DeserializeObject<List<ProdutoModel>>(json);

            for (int i = 0; i < produto.Count; i++)
            {
                if (id == produto[i].Id)
                    return produto[i];
            }

            return null;
        }

        public List<ProdutoModel> GetProdutoList()
        {

            var sr = new StreamReader(@"database\Produtos.json");
            string json = sr.ReadToEnd();
            sr.Close();


            var produto = JsonConvert.DeserializeObject<List<ProdutoModel>>(json);
            return produto;

        }

        public async Task<ProdutoModel> PostProduto(string nome, double preco, string descricao, int quantidade, double peso, double desconto, string urlImagem)
        {
            var produto = new ProdutoModel(nome, preco, descricao, quantidade, peso, desconto, new List<ImageModel>() { new ImageModel(urlImagem) });
            var leitor = new StreamReader(@"database\Produtos.json");

            var produtos = leitor.ReadToEnd();
            produtos = produtos.Remove(produtos.Length-1, 1);

            leitor.Close();

            var sw = new StreamWriter(@"database\Produtos.json");
            var json = JsonConvert.SerializeObject(produto).Replace(",", ",\n");

            await sw.WriteAsync(produtos + ",\n" + json + "\n]");

            sw.Close();

            return produto;
        }
    }
}
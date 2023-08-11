using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeowMeowShopAPI.models;
using MeowMeowShopAPI.repositories.interfaces;

namespace MeowMeowShopAPI.repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private static readonly List<ProdutoModel> produtos = new()
        {
            new ProdutoModel("colar com correntes e cruz", 55.00, "para quem gosta daquela pegada mais gótica", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("./assets/img/img0 id0.png")}),
            new ProdutoModel("choker de estela", 25.00, "quem aí não adora o estilo y2k???", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("./assets/img/img0 id1.png")}),
            new ProdutoModel("colar com lua", 25.00, "para quem tem uma vibe mais mística e misteriosa", 4, 0.3, 10, new List<ImageModel>(){new ImageModel("./assets/img/img0 id2.png")}),
            new ProdutoModel("colar de pérolas com cruz", 45.00, "um lindo colar de pérolas com uma cruz", 2, 12.4, 50, new List<ImageModel>(){new ImageModel("./assets/img/img0 id3.png")}),
            new ProdutoModel("pulseira de teste", 30.00, "uma pulseira de teste", 2, 12.4, 50, new List<ImageModel>(){new ImageModel("./assets/img/img1 id2.png")})
        };

        public ProdutoModel? GetProdutoById(int id)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                if (id == produtos[i].Id)
                    return produtos[i];
            }

            return null;
        }

        public List<ProdutoModel> GetProdutoList()
        {
            return produtos;
        }
    }
}
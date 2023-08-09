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
            new ProdutoModel("colar", 55.00, "é um colar", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("a")}),
            new ProdutoModel("pulseira", 15.00, "é uma pulseira", 1, 0.5, 0, new List<ImageModel>(){new ImageModel("b")}),
            new ProdutoModel("roupa", 30.00, "é uma roupa", 4, 0.3, 10, new List<ImageModel>(){new ImageModel("c")}),
            new ProdutoModel("tenis", 155.00, "é um tenis", 2, 12.4, 50, new List<ImageModel>(){new ImageModel("d")})
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
    }
}
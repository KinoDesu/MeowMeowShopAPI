using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeowMeowShopAPI.models;

namespace MeowMeowShopAPI.repositories.interfaces
{
    public interface IProdutoRepository
    {
        ProdutoModel? GetProdutoById(int id);
        List<ProdutoModel> GetProdutoList();
    }
}
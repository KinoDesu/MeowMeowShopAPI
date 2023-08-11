using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeowMeowShopAPI.models;

namespace MeowMeowShopAPI.services.interfaces
{
    public interface IProdutoService
    {
        ProdutoModel? GetProdutoById(int id);
        List<ProdutoModel> GetProdutoList();
    }
}
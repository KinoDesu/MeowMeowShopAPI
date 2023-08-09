using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
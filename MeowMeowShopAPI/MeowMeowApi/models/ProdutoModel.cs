namespace MeowMeowShopAPI.MeowMeowApi.models
{
    public class ProdutoModel
    {
        private static int Count { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double Peso { get; set; }
        public double Desconto { get; set; }
        public List<ImageModel> Imagens { get; set; }

        public ProdutoModel(string nome, double preco, string descricao, int quantidade, double peso, double desconto, List<ImageModel> imagens)
        {
            Id = ++Count;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Quantidade = quantidade;
            Peso = peso;
            Desconto = desconto;
            Imagens = imagens;
        }


        public ProdutoModel() { }
    }
}
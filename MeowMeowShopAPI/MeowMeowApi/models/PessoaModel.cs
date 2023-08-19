namespace MeowMeowShopAPI.MeowMeowApi.models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public long Cep { get; set; }
        public string Endereco { get; set; }
        public string? Complemento { get; set; }
        public string Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? Imagem { get; set; }

        public PessoaModel(int id, string nome, string sobrenome, long cpf, string email, long cep, string endereco, string? complemento, string telefone1, string? telefone2, string? imagem)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Email = email;
            Cep = cep;
            Endereco = endereco;
            Complemento = complemento;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            Imagem = imagem;
        }

        public PessoaModel() { }
    }
}

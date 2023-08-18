namespace MeowMeowShopAPI.MeowMeowApi.models
{
    public class ImageModel
    {
        private static int Count { get; set; }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string Link { get; set; }


        public ImageModel(int IdProduto, string Link)
        {
            this.Id = ++Count;
            this.IdProduto = IdProduto;
            this.Link = Link;
        }

        public ImageModel() { }
    }

}
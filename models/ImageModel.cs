namespace MeowMeowShopAPI.models
{
    public class ImageModel
    {
        public string url { get; set; }

        public ImageModel(string url)
        {
            this.url = url;
        }
    }
}
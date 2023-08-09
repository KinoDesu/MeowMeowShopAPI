using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
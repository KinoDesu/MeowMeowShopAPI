using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace MeowMeowShopAPI
{
    public class LambdaFunction : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
        {
            protected override void Init(IWebHostBuilder builder)
            {
                builder
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Program>()
                    .UseLambdaServer();
            }
        }
    }
}
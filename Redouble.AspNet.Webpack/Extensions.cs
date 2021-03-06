using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Redouble.AspNet.Webpack
{
    public static class Extensions
    {
        public static void AddWebpack(this IServiceCollection services,
           string configFile = "webpack.config.js",
           string publicPath = "/",
           string webRoot = "wwwroot",
           WebpackLogLevel logLevel = WebpackLogLevel.Normal)
        {
            var options = new WebpackOptions();
            options.ConfigFile = configFile;
            options.PublicPath = publicPath;
            options.WebRoot = webRoot;
            options.LogLevel = logLevel;
            options.Heartbeat = 10000;

            services.AddSingleton<WebpackOptions>(options);
            services.AddSingleton<IWebpackService, WebpackService>();
        }

        public static void UseWebpackHotReload(this IApplicationBuilder app)
        {
            app.UseMiddleware<HotReload>();
        }

        public static void UseWebpackDevServer(this IApplicationBuilder app)
        {
            app.UseMiddleware<DevServer>();
        }
    }
}
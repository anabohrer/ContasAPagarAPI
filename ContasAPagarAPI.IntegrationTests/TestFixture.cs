using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

namespace ContasAPagarAPI.IntegrationTests
{
    public class TestFixture<TStartup> : IDisposable
    {
        public static string GetCaminhoProjeto(string projectRelativePath, Assembly startupAssembly)
        {
            var nomeProjeto = startupAssembly.GetName().Name;
            var diretorioBaseArquivo = AppContext.BaseDirectory;
            var diretorioInfo = new DirectoryInfo(diretorioBaseArquivo);
            do
            {
                diretorioInfo = diretorioInfo.Parent;

                var diretorioProjetoInfo = new DirectoryInfo(Path.Combine(diretorioInfo.FullName, projectRelativePath));

                if (diretorioProjetoInfo.Exists)
                    if (new FileInfo(Path.Combine(diretorioProjetoInfo.FullName, nomeProjeto, $"{nomeProjeto}.csproj")).Exists)
                        return Path.Combine(diretorioProjetoInfo.FullName, nomeProjeto);
            }
            while (diretorioInfo.Parent != null);

            throw new Exception($"Raiz do projeto não pôde ser localizada usando {diretorioBaseArquivo}.");

        }
        private readonly TestServer Server;

        public TestFixture()
           : this(Path.Combine(""))
        {
        }
        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
        protected virtual void InicializaServicos(IServiceCollection services)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            var manager = new ApplicationPartManager
            {
                ApplicationParts =
                {
                    new AssemblyPart(startupAssembly)
                },
                FeatureProviders =
                {
                    new ControllerFeatureProvider(),
                    new ViewComponentFeatureProvider()
                }
            };

            services.AddSingleton(manager);
        }

        protected TestFixture(string relativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var contentRoot = GetCaminhoProjeto(relativeTargetProjectParentDir, startupAssembly);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InicializaServicos)
                .UseConfiguration(configurationBuilder.Build())
                .UseEnvironment("Development")
                .UseStartup(typeof(TStartup));

            // Create instance of test server
            Server = new TestServer(webHostBuilder);

            // Add configuration for client
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:51855/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

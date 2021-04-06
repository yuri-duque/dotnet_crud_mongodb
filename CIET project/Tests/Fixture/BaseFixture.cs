using IoT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;

namespace Tests.Fixture
{
    public class BaseFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public BaseFixture()
        {
            var configuration = GetConfiguration();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection
                .AddSingleton<IConfiguration>(configuration)
                .AddMongo()
                .AddServices()
                .AddRepositories();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        private IConfiguration GetConfiguration()
        {
            var basePath = GetContentRootPath();

            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            const string relativePathToWebProject = @"../../../../Api";

            return Path.Combine(testProjectPath, relativePathToWebProject);
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
        }
    }
}

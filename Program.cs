using System;
using System.Threading.Tasks;
using test_project_01.Models;
using test_project_01.Repositories;
using test_project_01.Services;

namespace test_project_01
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var providerRepo = new ProfileRepository();
            var profileRepo = new ProviderRepository();
            var api = new ApiService(profileRepo, providerRepo);
            var result = await api.GetItemsAsync(new[] {
                new ProviderLocationHandle { ProviderId = 1, LocationCode = "l-1" },
                new ProviderLocationHandle { ProviderId = 2, LocationCode = "2-not-exist" },
                new ProviderLocationHandle { ProviderId = 10, LocationCode = "10-not-exist" },
                new ProviderLocationHandle { ProviderId = 3, LocationCode = "l-3-c"}
            });

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            Console.WriteLine(str);

        }
    }
}

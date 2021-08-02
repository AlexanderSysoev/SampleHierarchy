using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project_01.Models;
using test_project_01.Repositories;

namespace test_project_01.Services
{
    public class ApiService
    {
        private readonly ProviderRepository _providerRepository;
        private readonly ProfileRepository _profileRepository;

        public ApiService(ProviderRepository providerRepository, ProfileRepository profileRepository) {
            this._providerRepository = providerRepository;
            this._profileRepository = profileRepository;
        }

        public async Task<IEnumerable<ProviderLocation>> GetItemsAsync(ProviderLocationHandle[] handlers)
        {
            var providers = await _providerRepository.FindAsync(handlers.Select(h => h.ProviderId).ToArray());
            var profiles = await _profileRepository.FindAsync(providers.Select(p => p.ActiveProfileId).ToArray());
            
            var results = new ProviderLocation[handlers.Length];

            for (var i = 0; i < handlers.Length; i++)
            {
                var handler = handlers[i];
                var provider = providers.FirstOrDefault(p => p.Id == handler.ProviderId);
                if (provider == null)
                {
                    results[i] = new ProviderLocation
                    {
                        ProviderId = handler.ProviderId,
                        LocationCode = handler.LocationCode,
                        Status = ProviderLocationStatus.ProvidrNotFound,
                        Found = false
                    };
                    continue;
                }

                var profile = profiles.FirstOrDefault(p => p.Id == provider.ActiveProfileId);
                if (profile == null)
                {
                    results[i] = new ProviderLocation
                    {
                        ProviderId = handler.ProviderId,
                        LocationCode = handler.LocationCode,
                        Status = ProviderLocationStatus.InvalidProfile,
                        Found = false
                    };
                    continue;
                }

                var location = profile.Locations.FirstOrDefault(l => l.code == handler.LocationCode);
                if (location == null)
                {
                    results[i] = new ProviderLocation
                    {
                        ProviderId = handler.ProviderId,
                        LocationCode = handler.LocationCode,
                        Status = ProviderLocationStatus.LocationNotFound,
                        Found = false,
                        Profile = profile,
                        Location = provider.Status == ProvideStatus.Active ? profile.Locations.FirstOrDefault() : null
                    };
                    continue;
                }
                
                results[i] = new ProviderLocation
                {
                    ProviderId = handler.ProviderId,
                    LocationCode = handler.LocationCode,
                    Status = ProviderLocationStatus.Found,
                    Found = true,
                    Profile = profile,
                    Location = location
                };
            }

            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project_01.Models;

namespace test_project_01.Repositories
{
    public class ProfileRepository
    {
        public ProfileRepository() { }

        public Task<IEnumerable<Profile>> FindAsync(int[] ids) {
            return Task.FromResult(_items.Where(x => ids.Contains(x.Id)));
        }

        static readonly Profile[] _items = new Profile[] {
            new Profile {
               Id = 1,
               Name = "demo #1",
               ProviderId = 1,
               ProviderType = ProviderType.Individual,
               Locations = new Location[] {
                   new Location {
                       code = "l-1",
                       Title = "title for #1"
                   }
               }
            },
            new Profile {
               Id = 2,
               Name = "demo #2",
               ProviderId = 2,
               ProviderType = ProviderType.Individual,
               Locations = new Location[] {
                   new Location {
                       code = "l-2",
                       Title = "title for #2"
                   }
               }
            },
            new Profile {
               Id = 3,
               Name = "demo #3",
               ProviderId = 3,
               ProviderType = ProviderType.Individual,
               Locations = new Location[] {
                   new Location {
                       code = "l-3",
                       Title = "title for #3"
                   }
               }
            },
            new Profile {
               Id = 5,
               Name = "demo #5",
               ProviderId = 3,
               ProviderType = ProviderType.Individual,
               Locations = new Location[] {
                   new Location {
                       code = "l-3-b",
                       Title = "title for #3-b"
                   },
                   new Location {
                       code = "l-3-c",
                       Title = "title for #3-c"
                   }
               }
            },
            new Profile {
               Id = 7,
               Name = "demo #7",
               ProviderId = 5,
               ProviderType = ProviderType.Individual,
               Locations = new Location[] {
                   new Location {
                       code = "l-5-b",
                       Title = "title for #5-b"
                   }
               }
            }
        };
    }
}

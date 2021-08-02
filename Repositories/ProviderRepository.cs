using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_project_01.Models;

namespace test_project_01.Repositories
{
    public class ProviderRepository
    {
        public ProviderRepository() { }

        public Task<IEnumerable<Provider>> FindAsync(int[] ids) {
            return Task.FromResult(_items.Where(x => ids.Contains(x.Id)));
        }

        static readonly Provider[] _items = new [] {
            new Provider {
               Id = 1,
               ActiveProfileId = 1,
               Status = ProvideStatus.Active
            },
            new Provider {
               Id = 2,
               ActiveProfileId = 2,
               Status = ProvideStatus.Active
            },
            new Provider {
               Id = 3,
               ActiveProfileId = 5,
               Status = ProvideStatus.Active
            },
            new Provider {
               Id = 4,
               ActiveProfileId = 7,
               Status = ProvideStatus.Active
            }
        };
    }
}

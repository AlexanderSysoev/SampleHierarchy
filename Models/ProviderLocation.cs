using System;
namespace test_project_01.Models
{
    public enum ProviderLocationStatus
    {
        Found = 1,
        InvalidProfile,
        LocationNotFound,
        ProvidrNotFound
    }

    public class ProviderLocationHandle
    {
        public int ProviderId { get; set; }
        public string LocationCode { get; set; }
    }

    public class ProviderLocation : ProviderLocationHandle
    {
        public ProviderLocationStatus Status { get; set; }
        public bool Found { get; set; }
        public Profile Profile { get; set; }
        public Location Location { get; set; }
    }
}

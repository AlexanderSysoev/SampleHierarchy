using System;
namespace test_project_01.Models
{
    public enum ProviderType
    {
        Individual = 1,
        Organization
    }

    public class Profile
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string overview { get; set; }
        public ProviderType ProviderType { get; set; }
        public Location[] Locations { get; set; }
    }
}

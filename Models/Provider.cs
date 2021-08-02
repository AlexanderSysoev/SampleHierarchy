using System;
namespace test_project_01.Models
{
    public enum ProvideStatus
    {
        Active = 1,
        Inactive,
        Removed
    }

    public class Provider
    {
        public int Id { get; set; }
        public int ActiveProfileId { get; set; }
        public ProvideStatus Status { get; set; }
    }
}

using System;

using Framework.Models.Entity;
namespace Abstract.Entities
{
    public class User : IPoco<int>, ITrackingInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
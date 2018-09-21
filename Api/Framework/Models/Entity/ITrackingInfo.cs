using System;

namespace Framework.Models.Entity
{
    public interface ITrackingInfo
    {
        DateTime? CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        long? CreatedBy { get; set; }
        long? ModifiedBy { get; set; }
    }
}
using System;
using Dapper.Contrib.Extensions;

namespace ProductBoundedContext.Data.EntityData
{
    [Table("UnitMeasurement")]
    public class UnitMeasurementEntityData
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
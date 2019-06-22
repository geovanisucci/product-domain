using System;
using Dapper.Contrib.Extensions;
using ProductBoundedContext.Domain.EntityDomain;

namespace ProductBoundedContext.Data.EntityData
{
    [Table("Product")]
    public class ProductEntityData
    {
        public string Id { get; set; }        
        public string Description { get; set; }
        public string BarCode { get; set; }
        public string UnitMeasurementId { get; set; }  
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }      
        public DateTime? UpdatedAt { get; set; } 


        public static ProductEntityDomain ToEntityDomain(ProductEntityData fromEntityData)
        {
            if(fromEntityData != null)
            {
                return new ProductEntityDomain()
                {
                    Id = fromEntityData.Id,
                    Description = fromEntityData.Description,
                    BarCode = fromEntityData.BarCode,
                    UnitMeasurementId = fromEntityData.UnitMeasurementId
                };
            }

            return null;
        }
        public static ProductEntityData ToEntityData(ProductEntityDomain fromEntityDomain)
        {
            if(fromEntityDomain != null)
            {
                return new ProductEntityData()
                {
                    Id = fromEntityDomain.Id,
                    Description = fromEntityDomain.Description,
                    BarCode = fromEntityDomain.BarCode,
                    UnitMeasurementId = fromEntityDomain.UnitMeasurementId
                };
            }

            return null;
        }

    }
}
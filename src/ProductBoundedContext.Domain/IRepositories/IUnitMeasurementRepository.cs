using System.Collections.Generic;
using System.Threading.Tasks;
using ProductBoundedContext.Domain.EntityDomain;

namespace ProductBoundedContext.Domain.IRepositories
{
    public interface IUnitMeasurementRepository
    {
        Task<UnitMeasurementEntityDomain> CreateUnitMeasurementAsync(UnitMeasurementEntityDomain unitMeasurement);
        Task<bool> UpdateUnitMeasurementAsync(UnitMeasurementEntityDomain unitMeasurement);
        Task<bool> RemoveUnitMeasurementAsync(string id);
        Task<List<UnitMeasurementEntityDomain>> GetAllUnitMeasurementAsync();
        Task<UnitMeasurementEntityDomain> GetUnitMeasurementAsync(string id);
    }
}
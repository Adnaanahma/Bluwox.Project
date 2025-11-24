using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;

namespace Bluwox.Repository.ServiceManagementRepo
{
    public interface IServiceManagementRepo
    {
        Task<bool> Add(string name, long catId, decimal baseFare);
        Task<bool> Update(ServiceManagement serviceManagement);
        Task<bool> ActivateAndDeactivate(ServiceManagement serviceManagement);
        Task<ServiceManagement> Get(long id);
        Task<PagedResult<ServiceManagement>> GetAll(int pageNumber, int pageSize);
        Task<PagedResult<ServiceManagement>> Filter(string serviceName, long category, DateTime startDate, DateTime endDate, int pageNumber, int pageSize);
        Task<bool> Delete(ServiceManagement serviceManagement);
    }
}

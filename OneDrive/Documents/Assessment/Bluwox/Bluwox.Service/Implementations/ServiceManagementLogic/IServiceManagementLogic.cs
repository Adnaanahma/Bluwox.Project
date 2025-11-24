using Bluwox.Model.Dtos;
using Bluwox.Model.ViewModels;

namespace Bluwox.Service.Implementations.ServiceManagementLogic
{
    public interface IServiceManagementLogic
    {
        Task<BaseResponse> Add(ServiceManagementRequest request);
        Task<BaseResponse> Update(ServiceManagementUpdateRequest request);
        Task<BaseResponse> ActivateAndDeactivate(ServiceManagementStatusRequest request);
        Task<BaseResponse> Delete(long id);
        Task<PageBaseResponse<ServiceManagementDto>> GetAll(int pageNumber = 1, int pageSize = 10);
        Task<PageBaseResponse<ServiceManagementDto>> GetByFilter(ServiceFilterRequest request);
    }
}

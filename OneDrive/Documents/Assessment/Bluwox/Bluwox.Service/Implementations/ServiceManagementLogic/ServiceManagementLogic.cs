using AutoMapper;
using Bluwox.Model.Dtos;
using Bluwox.Model.Entities;
using Bluwox.Model.ViewModels;
using Bluwox.Repository.ServiceManagementRepo;

namespace Bluwox.Service.Implementations.ServiceManagementLogic
{
    public class ServiceManagementLogic: IServiceManagementLogic
    {
        private readonly IServiceManagementRepo _serviceManagementRepo;
        private readonly IMapper _mapper;

        public ServiceManagementLogic(IServiceManagementRepo serviceManagementRepo, IMapper mapper)
        {
            _serviceManagementRepo = serviceManagementRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// "add service logic"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Add(ServiceManagementRequest request)
        {
            var repoResponse = await _serviceManagementRepo.Add(request.Name, request.CategoryId, request.BaseFare);

            return repoResponse ? BaseResponse.Success("Service created succesfully") : BaseResponse.Failure("Adding new service failed.");
        }

        /// <summary>
        /// "update service logic"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Update(ServiceManagementUpdateRequest request)
        {
            var data = await _serviceManagementRepo.Get(request.Id);
            if (data == null) BaseResponse.Failure("Service record does not exist.");

            data.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : data.Name;
            data.CategoryId = request.CategoryId > 0 ? request.CategoryId : data.CategoryId;
            data.BaseFare = request.BaseFare > 0 ? request.BaseFare : data.BaseFare;

            var repoResponse = await _serviceManagementRepo.Update(data);

            return repoResponse ? BaseResponse.Success("Service updated succesfully") : BaseResponse.Failure("Updating selected service failed.");
        }

        /// <summary>
        /// "activate-deactivate status logic"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> ActivateAndDeactivate(ServiceManagementStatusRequest request)
        {
            var data = await _serviceManagementRepo.Get(request.Id);
            if (data == null) BaseResponse.Failure("Service record does not exist.");
            if (data.Status == request.Status) BaseResponse.Success("Service status updated succesfully");

            data.Status = request.Status;

            var repoResponse = await _serviceManagementRepo.ActivateAndDeactivate(data);

            return repoResponse ? BaseResponse.Success("Service status updated succesfully") : BaseResponse.Failure("Updating selected service failed.");
        }

        /// <summary>
        /// "delete service logic"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResponse> Delete(long id)
        {
            var data = await _serviceManagementRepo.Get(id);
            if (data == null) BaseResponse.Failure("Service record does not exist.");

            var repoResponse = await _serviceManagementRepo.Delete(data);

            return repoResponse ? BaseResponse.Success("Service deleted succesfully") : BaseResponse.Failure("Deleting selected service failed.");
        }

        /// <summary>
        /// "load service page logic"
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PageBaseResponse<ServiceManagementDto>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var repoResponse = await _serviceManagementRepo.GetAll(pageNumber, pageSize);
            var mappedData = _mapper.Map<IEnumerable<ServiceManagementDto>>(repoResponse.Data);

            return PageBaseResponse<ServiceManagementDto>.Success(mappedData, "Record retrieved successfully", repoResponse.CurrentPage, repoResponse.HasNextPage, repoResponse.TotalRecordInStore);
        }

        public async Task<PageBaseResponse<ServiceManagementDto>> GetByFilter(ServiceFilterRequest request)
        {
            var repoResponse = await _serviceManagementRepo.Filter(request.ServiceName, request.Category, request.StartDate, request.EndDate, request.PageNumber, request.PageSize);
            var mappedData = _mapper.Map<IEnumerable<ServiceManagementDto>>(repoResponse.Data);

            return PageBaseResponse<ServiceManagementDto>.Success(mappedData, "Record retrieved successfully", repoResponse.CurrentPage, repoResponse.HasNextPage, repoResponse.TotalRecordInStore);
        }
    }
}

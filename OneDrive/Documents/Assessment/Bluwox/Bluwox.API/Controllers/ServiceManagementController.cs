using System.Net;
using Bluwox.Model.Dtos;
using Bluwox.Model.ViewModels;
using Bluwox.Service.Implementations.ServiceManagementLogic;
using Microsoft.AspNetCore.Mvc;

namespace Bluwox.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServiceManagementController : ControllerBase
    {
        private readonly IServiceManagementLogic _logic;

        public ServiceManagementController(IServiceManagementLogic logic)
        {
            _logic = logic;
        }

        // add service endpoint
        [HttpPost("add")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] ServiceManagementRequest request)
        {
            var response = await _logic.Add(request);
            return Ok(response);
        }

        // load whole page endpoint
        [HttpPost("get-all")]
        [ProducesResponseType(typeof(PageBaseResponse<ServiceManagementDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll([FromBody] PageRequest request)
        {
            var response = await _logic.GetAll(request.PageNumber, request.PageSize);
            return Ok(response);
        }

        // update service endpoint
        [HttpPut("update")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([FromBody] ServiceManagementUpdateRequest request)
        {
            var response = await _logic.Update(request);
            return Ok(response);
        }

        // active status endpoint
        [HttpPut("status-update")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ActivateAndDeactivate([FromBody] ServiceManagementStatusRequest request)
        {
            var response = await _logic.ActivateAndDeactivate(request);
            return Ok(response);
        }

        // delete service endpoint
        [HttpDelete("delete")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] long Id)
        {
            var response = await _logic.Delete(Id);
            return Ok(response);
        }


        [HttpPut("filter")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Filter([FromBody] ServiceFilterRequest request)
        {
            var response = await _logic.GetByFilter(request);
            return Ok(response);
        }
    }
}

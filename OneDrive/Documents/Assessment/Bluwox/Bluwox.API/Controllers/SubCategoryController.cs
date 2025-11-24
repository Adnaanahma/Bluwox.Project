using System.Net;
using Bluwox.Model.ViewModels;
using Bluwox.Service.Implementations.CategoryLogic;
using Bluwox.Service.Implementations.SubCategoryLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bluwox.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryLogic _subLogic;

        public SubCategoryController(ISubCategoryLogic subLogic)
        {
            _subLogic = subLogic;
        }

        // add sub-category endpoint
        [HttpPost("add")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] SubCategoryRequest request)
        {
            var response = await _subLogic.Add(request);
            return Ok(response);
        }
    }
}

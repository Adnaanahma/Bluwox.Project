using System.Net;
using Bluwox.Model.ViewModels;
using Bluwox.Service.Implementations.CategoryLogic;
using Microsoft.AspNetCore.Mvc;

namespace Bluwox.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryLogic _logic;

        public CategoryController(ICategoryLogic logic)
        {
            _logic = logic;
        }

        // add endpoint
        [HttpPost("add")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add([FromBody] CategoryRequest request)
        {
            var response = await _logic.Add(request);
            return Ok(response);
        }

        // get all end point
        [HttpGet("get-all")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _logic.GetAll();
            return Ok(response);
        }


    }
}

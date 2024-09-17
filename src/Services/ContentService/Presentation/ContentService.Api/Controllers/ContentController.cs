using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ContentService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateUserCommandResponse>> UpdateUser(UpdateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}

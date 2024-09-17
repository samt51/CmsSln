using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ContentService.Application.Feature.Contents.Commands.DeleteContent;
using MassTransit.Monitoring.Performance;
using ContentService.Application.Feature.Contents.Commands.CreateContent;
using ContentService.Application.Feature.Contents.Queries.GetByIdContent;
using ContentService.Application.Feature.Contents.Queries.GetAllContent;

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
        [HttpGet]
        public async Task<ResponseDto<IList<GetAllContentQueyResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllContentQueyRequest());
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdContentQueryResponse>> GetByIdAsync(int id)
        {
            return await _mediator.Send(new GetByIdContentQueryRequest(id));
        }
        [HttpPost]
        public async Task<ResponseDto<CreateContentCommandResponse>> CreateAsync(CreateContentCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteContentCommandResponse>> DeleteAsync(int id)
        {
            return await _mediator.Send(new DeleteContentCommandRequest(id));
        }
        [HttpPut]
        public async Task<ResponseDto<UpdateUserCommandResponse>> UpdateUser(UpdateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}

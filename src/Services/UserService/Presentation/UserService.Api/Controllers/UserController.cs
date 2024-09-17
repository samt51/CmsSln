using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Feature.User.Commands.CreateUser;
using UserService.Application.Feature.User.Commands.DeleteUser;
using UserService.Application.Feature.User.Commands.UpdateUser;
using UserService.Application.Feature.User.Queries.GetAllUser;
using UserService.Application.Feature.User.Queries.GetByIdUser;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<IList<GetAllUserQueryResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllUserQueryRequest());
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdUserQueryResponse>> GetByIdAsync(int id)
        {
            return await _mediator.Send(new GetByIdUserQueryRequest(id));
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteUserCommandResponse>> DeleteAsync(int id)
        {
            return await _mediator.Send(new DeleteUserCommandRequest(id));
        }
        [HttpPut]
        public async Task<ResponseDto<UpdateUserCommandResponse>> UpdateAsync(UpdateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateUserCommandResponse>> CreateAsync(CreateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}

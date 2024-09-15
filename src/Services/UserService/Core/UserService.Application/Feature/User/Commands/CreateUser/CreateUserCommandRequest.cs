using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Commands.CreateUser
{
    public class CreateUserCommandRequest : IRequest<ResponseDto<CreateUserCommandResponse>>
    {
        public string Name { get; }
        public string Email { get; }
        public CreateUserCommandRequest(string name, string email)
        {

            this.Name = name;
            this.Email = email;
        }
    }
}

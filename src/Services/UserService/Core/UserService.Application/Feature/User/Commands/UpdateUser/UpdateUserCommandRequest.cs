using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Commands.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<ResponseDto<UpdateUserCommandResponse>>
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public UpdateUserCommandRequest(int id, string name, string email)
        {
            this.Name = name;
            this.Id = id;
            this.Email = email;
        }
    }
}

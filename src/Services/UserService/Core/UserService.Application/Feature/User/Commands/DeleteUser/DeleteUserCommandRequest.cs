using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Commands.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest<ResponseDto<DeleteUserCommandResponse>>
    {
        public int Id { get; }
        public DeleteUserCommandRequest(int userId)
        {
            this.Id = userId;
        }
    }
}

using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : BaseHandler, IRequestHandler<DeleteUserCommandRequest, ResponseDto<DeleteUserCommandResponse>>
    {
        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

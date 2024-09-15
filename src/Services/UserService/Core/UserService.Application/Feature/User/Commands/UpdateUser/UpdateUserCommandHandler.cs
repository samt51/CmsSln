using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommandRequest, ResponseDto<UpdateUserCommandResponse>>
    {
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

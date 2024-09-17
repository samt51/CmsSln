using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;
using System.Threading.Tasks;
using UserService.Domain.Entities;

namespace UserService.Application.Feature.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommandRequest, ResponseDto<UpdateUserCommandResponse>>
    {
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Users>().FindAsync(y => y.Id == request.Id && !y.IsDeleted);

            var map = mapper.Map<Users, UpdateUserCommandRequest>(request);

            var save = await unitOfWork.GetWriteRepository<Users>().UpdateAsync(map);

            if (await unitOfWork.SaveAsync() > 0)
            {
                return new ResponseDto<UpdateUserCommandResponse>().Success();
            }
            return new ResponseDto<UpdateUserCommandResponse>().Fail();
        }
    }
}

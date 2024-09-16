using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;
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

            var map = mapper.Map<UpdateUserCommandRequest, Users>(request);

            var save = await unitOfWork.GetWriteRepository<Users>().UpdateAsync(map);

            if (await unitOfWork.SaveAsync() > 0)
            {
                return new ResponseDto<UpdateUserCommandResponse>().Success();
            }
            unitOfWork.RollBack();
            return new ResponseDto<UpdateUserCommandResponse>().Fail("Bir hata oluştu", 400);
        }
    }
}

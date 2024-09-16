using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Feature.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : BaseHandler, IRequestHandler<DeleteUserCommandRequest, ResponseDto<DeleteUserCommandResponse>>
    {
        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Users>().FindAsync(y => y.Id == request.Id && !y.IsDeleted);

            data.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Users>().UpdateAsync(data);
            
            if(await unitOfWork.SaveAsync() > 0)
            {
                unitOfWork.Commit();
                return new ResponseDto<DeleteUserCommandResponse>().Success();
            }
            unitOfWork.RollBack();
            return new ResponseDto<DeleteUserCommandResponse>().Fail("Bir hata oluştu", 400);
        }
    }
}

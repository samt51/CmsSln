using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Feature.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommandRequest, ResponseDto<CreateUserCommandResponse>>
    {
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<Users, CreateUserCommandRequest>(request);

            unitOfWork.OpenTransaction();

            var save = await unitOfWork.GetWriteRepository<Users>().AddAsync(map);

            if (await unitOfWork.SaveAsync() > 0)
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<CreateUserCommandResponse>().Success();
            }
            unitOfWork.RollBack();
            return new ResponseDto<CreateUserCommandResponse>().Fail("Bir hata oluştu.", 400);

        }
    }
}

using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
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
            var map = mapper.Map<CreateUserCommandRequest, Users>(request);

            var save = await unitOfWork.GetWriteRepository<Users>().AddAsync(map);

            if (await unitOfWork.SaveAsync() > 0)
            {
                unitOfWork.Commit();
                return new ResponseDto<CreateUserCommandResponse>().Success();
            }
            unitOfWork.RollBack();
            return new ResponseDto<CreateUserCommandResponse>().Fail("Bir hata oluştu.", 400);

        }
    }
}

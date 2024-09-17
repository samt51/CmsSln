using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Domain.Entites;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.CreateContent
{
    public class CreateContentCommandHandler : BaseHandler, IRequestHandler<CreateContentCommandRequest, ResponseDto<CreateContentCommandResponse>>
    {
        public CreateContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateContentCommandResponse>> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<Content, CreateContentCommandRequest>(request);

            unitOfWork.OpenTransaction();

            await unitOfWork.GetWriteRepository<Content>().AddAsync(data);

            if (await unitOfWork.SaveAsync() > 0)
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<CreateContentCommandResponse>().Success();
            }
            return new ResponseDto<CreateContentCommandResponse>().Fail();
        }
    }
}

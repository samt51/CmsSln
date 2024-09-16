using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.CreateContent
{
    public class CreateContentCommandHandler : BaseHandler, IRequestHandler<CreateContentCommandRequest, ResponseDto<CreateContentCommandResponse>>
    {
        public CreateContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<CreateContentCommandResponse>> Handle(CreateContentCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

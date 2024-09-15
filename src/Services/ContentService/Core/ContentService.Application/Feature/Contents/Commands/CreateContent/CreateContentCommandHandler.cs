using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
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

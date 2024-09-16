using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandHandler : BaseHandler, IRequestHandler<UpdateContentCommandRequest, ResponseDto<UpdateContentCommandResponse>>
    {
        public UpdateContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<UpdateContentCommandResponse>> Handle(UpdateContentCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

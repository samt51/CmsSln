using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandHandler : BaseHandler, IRequestHandler<DeleteContentCommandRequest, ResponseDto<DeleteContentCommandResponse>>
    {
        public DeleteContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<DeleteContentCommandResponse>> Handle(DeleteContentCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

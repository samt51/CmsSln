using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
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

using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetAllContent
{
    public class GetAllContentQueyHandler : BaseHandler, IRequestHandler<GetAllContentQueyRequest, ResponseDto<GetAllContentQueyResponse>>
    {
        public GetAllContentQueyHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<GetAllContentQueyResponse>> Handle(GetAllContentQueyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

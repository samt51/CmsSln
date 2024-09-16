using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
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

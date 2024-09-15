using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetByIdContent
{
    public class GetByIdContentQueryHandler : BaseHandler, IRequestHandler<GetByIdContentQueryRequest, ResponseDto<GetByIdContentQueryResponse>>
    {
        public GetByIdContentQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<GetByIdContentQueryResponse>> Handle(GetByIdContentQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

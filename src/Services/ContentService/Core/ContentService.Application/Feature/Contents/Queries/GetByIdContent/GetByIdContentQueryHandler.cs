using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos;
using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.UserEvents;
using ContentService.Domain.Entites;
using MassTransit;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetByIdContent
{
    public class GetByIdContentQueryHandler : BaseHandler, IRequestHandler<GetByIdContentQueryRequest, ResponseDto<GetByIdContentQueryResponse>>
    {
        private readonly IRequestClient<UserSelectedByIdEvent> _requestClient;
        public GetByIdContentQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IRequestClient<UserSelectedByIdEvent> requestClient) : base(mapper, unitOfWork)
        {
            _requestClient = requestClient;
        }

        public async Task<ResponseDto<GetByIdContentQueryResponse>> Handle(GetByIdContentQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Content>().FindAsync(y => y.Id == request.Id && !y.IsDeleted);

            var map = mapper.Map<GetByIdContentQueryResponse, Content>(data);

            var response = await _requestClient.GetResponse<ContentUserResponseDto>(new UserSelectedByIdEvent { Id = request.Id });

            map.contentUserResponseDto = response.Message;

            return new ResponseDto<GetByIdContentQueryResponse>().Success(map);


        }
    }
}

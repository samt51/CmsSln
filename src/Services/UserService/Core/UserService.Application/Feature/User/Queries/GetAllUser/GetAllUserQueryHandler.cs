using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.ContentEvents;
using MassTransit;
using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Feature.User.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : BaseHandler, IRequestHandler<GetAllUserQueryRequest, ResponseDto<IList<GetAllUserQueryResponse>>>
    {
        private readonly IRequestClient<ContentSelectedEvent> _requestClient;

        public GetAllUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IRequestClient<ContentSelectedEvent> requestClient) : base(mapper, unitOfWork)
        {
            _requestClient = requestClient;
        }

        public async Task<ResponseDto<IList<GetAllUserQueryResponse>>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.GetReadRepository<Users>().GetAllAsync(x => !x.IsDeleted);

            var contentResponse = await _requestClient.GetResponse<ContentResponseDtoItems>(new ContentSelectedEvent());


            var contentByUserId = contentResponse.Message.contentResponseDtos.GroupBy(c => c.UserId).ToDictionary(g => g.Key, g => g.ToList());

            var userResponses = users.Select(user => new GetAllUserQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                contentResponseDtos = contentByUserId.ContainsKey(user.Id) ? contentByUserId[user.Id] : new List<ContentResponseDto>()
            });

            return new ResponseDto<IList<GetAllUserQueryResponse>>().Success(userResponses.ToList());



        }
    }
}

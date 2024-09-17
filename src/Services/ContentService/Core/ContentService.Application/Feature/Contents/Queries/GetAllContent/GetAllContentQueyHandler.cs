using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos;
using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.UserEvents;
using ContentService.Domain.Entites;
using MassTransit;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetAllContent
{
    public class GetAllContentQueyHandler : BaseHandler, IRequestHandler<GetAllContentQueyRequest, ResponseDto<IList<GetAllContentQueyResponse>>>
    {
        private readonly IRequestClient<UserSelectedEvent> _requestClient;

        public GetAllContentQueyHandler(IMapper mapper, IUnitOfWork unitOfWork, IRequestClient<UserSelectedEvent> requestClient) : base(mapper, unitOfWork)
        {
            _requestClient = requestClient;
        }

        public async Task<ResponseDto<IList<GetAllContentQueyResponse>>> Handle(GetAllContentQueyRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Content>().GetAllAsync(x => !x.IsDeleted);


            var response = await _requestClient.GetResponse<UserResponseDtoItems>(new UserSelectedEvent());

            var rsp = response.Message;

            var query = from d1 in data
                        join d2 in rsp.userResponseDtos on d1.UserId equals d2.Id
                        select new GetAllContentQueyResponse
                        {
                            Id = d1.Id,
                            Title = d1.Title,
                            Description = d1.Description,
                            Body = d1.Body,
                            contentUserResponseDto = new ContentUserResponseDto
                            {
                                Id = d2.Id,
                                Email = d2.Email,
                                Name = d2.Name,
                            }
                        };

            return new ResponseDto<IList<GetAllContentQueyResponse>>().Success(query.ToList());
        
        }
    }
}

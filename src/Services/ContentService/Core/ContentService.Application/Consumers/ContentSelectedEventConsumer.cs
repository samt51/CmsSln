using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.ContentEvents;
using ContentService.Domain.Entites;
using MassTransit;

namespace ContentService.Application.Consumers
{
    public class ContentSelectedEventConsumer : IConsumer<ContentSelectedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContentSelectedEventConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<ContentSelectedEvent> context)
        {
            var contents = await _unitOfWork.GetReadRepository<Content>().GetAllAsync(x => !x.IsDeleted);

            var map = _mapper.Map<ContentResponseDto, Content>(contents);

            var ent = new ContentResponseDtoItems { contentResponseDtos = map };

            await context.RespondAsync(ent);
        }
    }
}

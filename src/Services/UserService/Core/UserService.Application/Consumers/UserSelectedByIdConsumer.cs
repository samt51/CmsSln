using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Dtos;
using Cms.Shared.MessageQuery.Events.UserEvents;
using MassTransit;
using UserService.Domain.Entities;

namespace UserService.Application.Consumers
{
    public class UserSelectedByIdConsumer : IConsumer<UserSelectedByIdEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserSelectedByIdConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<UserSelectedByIdEvent> context)
        {
            var data = await _unitOfWork.GetReadRepository<Users>().FindAsync(x => x.Id == context.Message.Id && !x.IsDeleted);

            var rsp = _mapper.Map<ContentUserResponseDto, Users>(data);

            await context.RespondAsync(rsp);
        }
    }
}

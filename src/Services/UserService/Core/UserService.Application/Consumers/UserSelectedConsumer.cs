
using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Dtos;
using Cms.Shared.MessageQuery.Events.UserEvents;
using MassTransit;
using UserService.Domain.Entities;

namespace UserService.Application.Consumers
{
    public class UserSelectedConsumer : IConsumer<UserSelectedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserSelectedConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<UserSelectedEvent> context)
        {
            var data = await _unitOfWork.GetReadRepository<Users>().GetAllAsync(x => !x.IsDeleted);

            var map = _mapper.Map<UserResponseDto, Users>(data);

            var ent=new UserResponseDtoItems {userResponseDtos=map};

            await context.RespondAsync(ent);
        }
    }
}

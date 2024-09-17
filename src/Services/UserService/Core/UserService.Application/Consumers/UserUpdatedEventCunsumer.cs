using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.MessageQuery.Events.UserEvents;
using MassTransit;
using UserService.Domain.Entities;

namespace UserService.Application.Consumers
{
    public class UserUpdatedEventCunsumer : IConsumer<UserUpdatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public UserUpdatedEventCunsumer(IPublishEndpoint publishEndpoint, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {

            var data = new Users { Id = 2, Name = "hasan" };
            data.Name = context.Message.Name;
            data.ModifyDate = DateTime.Now;

            _unitOfWork.OpenTransaction();

            await _unitOfWork.GetWriteRepository<Users>().AddAsync(data);

            if (await _unitOfWork.SaveAsync() > 0)
            {
                await _unitOfWork.CommitAsync();
                await _publishEndpoint.Publish(new UserUpdatedCompletedEvent { IsSuccess = true });
            }
            else
            {
                await _publishEndpoint.Publish(new UserUpdatedFailedEvent { IsSuccess = false, Message = "Bir hata oluştu" });
            }
        }
    }
}

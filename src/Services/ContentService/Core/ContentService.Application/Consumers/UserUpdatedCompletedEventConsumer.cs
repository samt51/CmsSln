using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.UserEvents;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using MassTransit;

namespace ContentService.Application.Consumers
{
    public  class UserUpdatedCompletedEventConsumer : IConsumer<UserUpdatedCompletedEvent>
    {
        public async Task Consume(ConsumeContext<UserUpdatedCompletedEvent> context)
        {
            var response = new ResponseDto<UpdateUserCommandResponse>
            {
                IsSuccess = true,
              
            };
          
        }
    }
}

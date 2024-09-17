using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery.Events.UserEvents;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using MassTransit;

namespace ContentService.Application.Consumers
{
    public class UserUpdatedFailedEventConsumer : IConsumer<UserUpdatedFailedEvent>
    {
        private readonly UpdateUserCommandHandler _handler;

        public UserUpdatedFailedEventConsumer(UpdateUserCommandHandler handler)
        {
            _handler = handler;
        }

        public async Task Consume(ConsumeContext<UserUpdatedFailedEvent> context)
        {

            var response = new ResponseDto<UpdateUserCommandResponse>().Fail(context.Message.Message, 400);
          
        }
    }
}

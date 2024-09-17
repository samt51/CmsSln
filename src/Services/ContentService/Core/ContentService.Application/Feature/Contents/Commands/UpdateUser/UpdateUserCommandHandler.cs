using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using Cms.Shared.MessageQuery;
using Cms.Shared.MessageQuery.Events.UserEvents;
using ContentService.Application.Consumers;
using MassTransit;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommandRequest, ResponseDto<UpdateUserCommandResponse>>
    {
        private readonly ISendEndpointProvider _sendEndpoint;

        public UpdateUserCommandHandler(ISendEndpointProvider sendEndpoint, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this._sendEndpoint = sendEndpoint;
        }

        public async Task<ResponseDto<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<UserUpdatedEvent, UpdateUserCommandRequest>(request);

            var sendEndPoint = await _sendEndpoint.GetSendEndpoint(new Uri($"queue:{RabbitMQSettingsConst.UserUpdatedEventQueueName}"));

            await sendEndPoint.Send(new UserUpdatedEvent { Id = 2, Name = "hasan" });

            var d = new UserUpdatedCompletedEventConsumer();
           




            return new ResponseDto<UpdateUserCommandResponse>().Success();

        }

    }
}

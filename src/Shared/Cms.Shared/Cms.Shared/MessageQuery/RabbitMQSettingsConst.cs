namespace Cms.Shared.MessageQuery
{
    public class RabbitMQSettingsConst
    {
        public const string UserUpdatedEventQueueName = "user-updated-queue";
        public const string UserUpdatedCompletedEventQueueName = "user-updated-completed-queue";
        public const string UserUpdatedFailedEventQueueName = "user-updated-failed-queue";
        public const string UserSelectedByIdEventQueueName = "user-selected-byid-queue";
        public const string UserSelectedEventQueueName = "user-selected-queue";
        public const string ContentSelectedEventQueueName = "content-selected-queue";
    }
}

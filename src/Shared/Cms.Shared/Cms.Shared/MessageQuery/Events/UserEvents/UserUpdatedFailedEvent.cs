namespace Cms.Shared.MessageQuery.Events.UserEvents
{
    public class UserUpdatedFailedEvent
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.CreateContent
{
    public class CreateContentCommandRequest : IRequest<ResponseDto<CreateContentCommandResponse>>
    {
        public string Title { get; }
        public string Description { get; }
        public string Body { get; }
        public int UserId { get; }
        public CreateContentCommandRequest(string title, string description, string body, int userId)
        {
            this.Title = title;
            this.Description = description;
            this.Body = body;
            this.UserId = userId;
        }
    }
}

using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandRequest : IRequest<ResponseDto<UpdateContentCommandResponse>>
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Body { get; }
    
        public UpdateContentCommandRequest(int id, string title, string description, string body)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Body = body;
        }
    }
}

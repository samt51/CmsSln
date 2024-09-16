
using Cms.Shared.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandRequest : IRequest<ResponseDto<DeleteContentCommandResponse>>
    {
        public int Id { get; }
        public DeleteContentCommandRequest(int contentId)
        {
            this.Id = contentId;
        }

    }
}

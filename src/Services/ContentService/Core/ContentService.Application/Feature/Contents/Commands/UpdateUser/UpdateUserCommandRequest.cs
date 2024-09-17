using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<ResponseDto<UpdateUserCommandResponse>>
    {
        public int Id { get; }
        public string Name { get; }

        public UpdateUserCommandRequest(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}

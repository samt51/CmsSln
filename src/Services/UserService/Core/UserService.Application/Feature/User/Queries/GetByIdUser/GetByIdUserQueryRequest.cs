using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Queries.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<ResponseDto<GetByIdUserQueryResponse>>
    {
        public int Id { get; }

        public GetByIdUserQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}

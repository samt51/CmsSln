using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace UserService.Application.Feature.User.Queries.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<ResponseDto<IList<GetAllUserQueryResponse>>>
    {
        public GetAllUserQueryRequest()
        {

        }
    }
}

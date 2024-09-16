using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;
using UserService.Domain.Entities;

namespace UserService.Application.Feature.User.Queries.GetByIdUser
{
    public class GetByIdUserQueryHandler : BaseHandler, IRequestHandler<GetByIdUserQueryRequest, ResponseDto<GetByIdUserQueryResponse>>
    {
        public GetByIdUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdUserQueryResponse>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Users>().FindAsync(y => y.Id == request.Id && !y.IsDeleted);

            var map = mapper.Map<GetByIdUserQueryResponse, Users>(data);

            return new ResponseDto<GetByIdUserQueryResponse>().Success(map);
        }
    }
}

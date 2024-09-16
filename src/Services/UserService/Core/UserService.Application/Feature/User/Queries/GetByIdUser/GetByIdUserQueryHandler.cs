using AutoMapper;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Dtos.ResponseModel;
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

            var map = mapper.Map<Users, GetByIdUserQueryResponse>(data);

            return new ResponseDto<GetByIdUserQueryResponse>().Success(map);
        }
    }
}

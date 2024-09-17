using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Domain.Entites;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandHandler : BaseHandler, IRequestHandler<UpdateContentCommandRequest, ResponseDto<UpdateContentCommandResponse>>
    {
        public UpdateContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateContentCommandResponse>> Handle(UpdateContentCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Content>().FindAsync(y => y.Id == request.Id && !y.IsDeleted);

            var map = mapper.Map<Content, UpdateContentCommandRequest>(request);

            unitOfWork.OpenTransaction();

            await unitOfWork.GetWriteRepository<Content>().UpdateAsync(map);
            if (await unitOfWork.SaveAsync() > 0)
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<UpdateContentCommandResponse>().Success();
            }
            return new ResponseDto<UpdateContentCommandResponse>().Fail();
        }
    }
}

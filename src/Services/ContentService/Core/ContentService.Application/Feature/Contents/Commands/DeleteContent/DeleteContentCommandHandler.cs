using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Bases.Base;
using Cms.Shared.Bases.Dtos.ResponseModel;
using ContentService.Domain.Entites;
using MediatR;

namespace ContentService.Application.Feature.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandHandler : BaseHandler, IRequestHandler<DeleteContentCommandRequest, ResponseDto<DeleteContentCommandResponse>>
    {
        public DeleteContentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteContentCommandResponse>> Handle(DeleteContentCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Content>().FindAsync(x => x.Id == request.Id && !x.IsDeleted);

            data.IsDeleted = true;

            unitOfWork.OpenTransaction();

            await unitOfWork.GetWriteRepository<Content>().UpdateAsync(data);

            if (await unitOfWork.SaveAsync() > 0)
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<DeleteContentCommandResponse>().Success();
            }
            return new ResponseDto<DeleteContentCommandResponse>().Fail();
        }
    }
}

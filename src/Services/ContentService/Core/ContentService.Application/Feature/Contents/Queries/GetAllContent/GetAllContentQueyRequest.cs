using Cms.Shared.Bases.Dtos.ResponseModel;
using MediatR;

namespace ContentService.Application.Feature.Contents.Queries.GetAllContent
{
    public class GetAllContentQueyRequest : IRequest<ResponseDto<GetAllContentQueyResponse>>
    {
    }
}

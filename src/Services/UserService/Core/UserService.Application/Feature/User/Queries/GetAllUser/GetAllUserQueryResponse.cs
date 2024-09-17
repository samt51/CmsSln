using Cms.Shared.Bases.Dtos.ResponseModel;

namespace UserService.Application.Feature.User.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<ContentResponseDto> contentResponseDtos { get; set; }
    }
}

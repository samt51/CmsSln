using Cms.Shared.Bases.Dtos;

namespace ContentService.Application.Feature.Contents.Queries.GetAllContent
{
    public class GetAllContentQueyResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public ContentUserResponseDto  contentUserResponseDto{ get; set; }
    }
}

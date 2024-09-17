namespace Cms.Shared.Bases.Dtos.ResponseModel
{
    public class ContentResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }


    }
    public class ContentResponseDtoItems
    {
        public IList<ContentResponseDto> contentResponseDtos { get; set; }


    }
}

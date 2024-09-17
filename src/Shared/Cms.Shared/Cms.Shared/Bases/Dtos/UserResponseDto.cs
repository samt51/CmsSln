namespace Cms.Shared.Bases.Dtos
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UserResponseDtoItems
    {
        public IList<UserResponseDto> userResponseDtos { get; set; }
    }
}

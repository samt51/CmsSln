using Cms.Shared.Bases.Common;

namespace UserService.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

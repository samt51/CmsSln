using Cms.Shared.Common;
using System.ComponentModel.DataAnnotations;

namespace UserService.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

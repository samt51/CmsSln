using Cms.Shared.Common;

namespace ContentService.Domain.Entites
{
    public class Content : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}

﻿namespace Cms.Shared.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifyDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

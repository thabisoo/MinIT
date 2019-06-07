using MinIT.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Domain.Models
{
    public class ItemStatus : ITimestamp
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.Items
{
    class ItemViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}

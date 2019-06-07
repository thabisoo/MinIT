using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinIT.Common.ViewModels.MeetingType
{
    public class MeetingTypeViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public IEnumerable<MeetingTypeViewModel> MeetingTypes { get; set; }
    }
}

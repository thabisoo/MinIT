using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.Domain.Models.Base
{
    interface ITimestamp 
    {
        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }
}

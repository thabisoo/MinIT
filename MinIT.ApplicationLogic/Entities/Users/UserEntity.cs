using System;
using System.Collections.Generic;
using System.Text;

namespace MinIT.ApplicationLogic.Entities.Users
{
    public class UserEntity
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserEntity> Users { get; set; }

    }
}

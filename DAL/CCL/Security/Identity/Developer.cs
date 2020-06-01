using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Developer
        : User
    {
        public Developer(int userId, string name)
            : base(userId, name, nameof(Developer))
        {
        }
    }
}
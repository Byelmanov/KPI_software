using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class CEO
        : User
    {
        public CEO(int userId, string name)
            : base(userId, name, nameof(CEO))
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    class Manager
    {
        public class Manager : User
        {
            public Manager(int userId, string name, int vendorCode): base(userId, name, vendorCode, nameof(Manager))
            {
            }
        }
    }
}

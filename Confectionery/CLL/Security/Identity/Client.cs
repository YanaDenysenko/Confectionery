using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    class Client
    {
        public class Client : User
        {
            public Client(int userId, string name, int vendorCode) : base(userId, name, vendorCode, nameof(Manager))
            {
            }
        }
    }
}

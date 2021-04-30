using System;
using System.Collections.Generic;
using System.Text;

namespace CLL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int vendorCode, string userType)
        {
            UserId = userId;
            Name = name;
            VendorCode = vendorCode;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int VendorCode { get; }
        protected string UserType { get; }
    }
}

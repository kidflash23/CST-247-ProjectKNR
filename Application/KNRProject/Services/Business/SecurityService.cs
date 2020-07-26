using KNRProject.Models;
using KNRProject.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KNRProject.Services
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO security = new SecurityDAO();
            return security.FindByUser(user);
        }
    }
}
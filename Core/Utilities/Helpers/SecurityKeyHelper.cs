﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Helpers
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
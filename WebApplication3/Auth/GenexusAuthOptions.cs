using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Auth
{
    public class GenexusAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "GENEXUS";
        public string Scheme => DefaultScheme;
        //outras opções aqui...
    }
}

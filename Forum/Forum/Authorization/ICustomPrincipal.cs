﻿using System.Security.Principal;

namespace Forum.Authorization
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Token { get; set; }
    }
}

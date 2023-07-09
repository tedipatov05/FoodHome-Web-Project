﻿using System.Security.Claims;

namespace FoodHome.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

using System.Collections.Concurrent;
using FoodHome.Extensions;
using Microsoft.Extensions.Caching.Memory;
using static FoodHome.Common.ApplicationConstants;

namespace FoodHome.Middlewares
{
    public class OnlineUserMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityMinutes;

        private static readonly ConcurrentDictionary<string, bool> AllKeys =
            new ConcurrentDictionary<string, bool>();


        public OnlineUserMiddleware(RequestDelegate _next, string _cookieName = OnlineUsersCookieName, int lastActivityMinutes = LastActivityBeforeOfflineMinutes)
        {
            this.next = _next;
            this.cookieName = _cookieName;
            this.lastActivityMinutes = lastActivityMinutes;
        }

        public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    // First login after being offline
                    userId = context.User.GetId()!;

                    context.Response.Cookies.Append(this.cookieName, userId, new CookieOptions() { HttpOnly = true, MaxAge = TimeSpan.FromDays(30) });
                }

                memoryCache.GetOrCreate(userId, cacheEntry =>
                {
                    if (!AllKeys.TryAdd(userId, true))
                    {
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(this.lastActivityMinutes);
                        cacheEntry.RegisterPostEvictionCallback(this.RemoveKeyWhenExpired);
                    }

                    return string.Empty;
                });
            }
            else
            {
                if (context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }

                    context.Response.Cookies.Delete(this.cookieName);
                }
            }

            return this.next(context);

        }

        public static bool CheckIfUserIsOnline(string userId)
        {
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            return success && valueTaken;
        }

        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyStr = (string)key; //UserId

            if (!AllKeys.TryRemove(keyStr, out _))
            {
                AllKeys.TryUpdate(keyStr, false, true);
            }
        }
    }

}

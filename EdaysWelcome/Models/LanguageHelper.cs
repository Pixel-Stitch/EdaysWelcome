using Microsoft.AspNetCore.Http;

namespace EdaysWelcome.Models
{
    public class LanguageHelper
    {
        public static string GetLanguagePreference(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.Cookies["languageCode"] ?? "en";
        }
    }
}

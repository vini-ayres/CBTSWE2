using P02_API_SDK.Dtos;
using P02_Web.Models;

namespace P02_Web.Utils
{
    public static class HttpResponseExtension
    {
        private static CookieOptions userCookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(1),
            HttpOnly = true
        };

        public static void toSaveCookieUser(this HttpResponse Response, UsuarioDTO usuario)
        {
            Response.Cookies.Append("UserId", usuario.Id.ToString(), userCookieOptions);
            Response.Cookies.Append("UserName", usuario.Nome, userCookieOptions);
        }

        public static void toClearCookieUser(this HttpResponse Response)
        {
            Response.Cookies.Append("UserId", "", userCookieOptions);
            Response.Cookies.Append("UserName","", userCookieOptions);
        }
    }

    public static class HttpRequestExtension
    {
        public static UsuarioDTO getCookieUser(this HttpRequest Request)
        {
            int userId = string.IsNullOrWhiteSpace(Request.Cookies["UserId"]) ? 0 : int.Parse(Request.Cookies["UserId"]);
            string userName = Request.Cookies["UserName"] ?? "";

            return new UsuarioDTO() { Nome = userName, Id = userId };
        }
    }
}

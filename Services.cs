using Dimensiona.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Dimensiona
{
    public class Services
    {

        public async Task Login(HttpContext ctx, UsuarioModel usuarios)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuarios.Email));
          

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    )
                );

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(8),
                IssuedUtc = DateTime.Now
            };


            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        public async Task Logoff(HttpContext ctx)
        {
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}

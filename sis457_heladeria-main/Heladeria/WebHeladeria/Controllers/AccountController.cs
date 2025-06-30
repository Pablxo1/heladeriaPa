using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebHeladeria.Models;
using static 
WebHeladeria.Models.AccountViewModels;

namespace WebHeladeria.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly FinalHeladeriaContext _context;

        public AccountController(FinalHeladeriaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Intentos de inicio de sesión no válidos.");
                return View(model);
            }

            var usuario = _context.Usuarios.Include(e => e.IdEmpleadoNavigation)
                .Where(x => x.Estado == 1 && x.Usuario1 == model.usuario &&
                    x.Clave == Encrypt(model.clave)).FirstOrDefault();
            if (usuario != null)
            {
                TempData["isLogged"] = true;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Usuario1),
                    new Claim("FullName", $"{usuario.IdEmpleadoNavigation.Nombres} {usuario.IdEmpleadoNavigation.PrimerApellido} {usuario.IdEmpleadoNavigation.SegundoApellido}"),
                    new Claim(ClaimTypes.Email, "carol.ss@12.bo"),
                    new Claim(ClaimTypes.Role, "admin", ClaimValueTypes.String)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1),
                    IsPersistent = model.recordarme
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                if (returnUrl == null) returnUrl = ViewData["ReturnUrl"]?.ToString();
                if (returnUrl != null) return Redirect(returnUrl);
                else return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                ModelState.AddModelError("", "Intentos de inicio de sesión no válidos.");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Cierra la sesión de autenticación
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Forzar eliminación manual de la cookie
            Response.Cookies.Append(".AspNetCore.Cookies", "", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(-1),
                Path = "/",
                HttpOnly = true,
                Secure = true, // Si usas HTTPS
                SameSite = SameSiteMode.Lax
            });

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "SIS457-1nf0!";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}

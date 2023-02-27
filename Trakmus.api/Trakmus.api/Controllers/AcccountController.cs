using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Trakmus.api.DAL;
using Trakmus.api.DAL.Models;
using Trakmus.api.Shared;

namespace Trakmus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcccountController : ControllerBase
    {
        private TrakMusContext _context;

        public AcccountController(TrakMusContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pwdHash = password.PasswordHash();

                    var pUser = _context

                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == username && u.Password == pwdHash);

                    user = new User()
                    {
                        DisplayName = "Jørgen Vig Jensen",
                        Email = "jvj@gmail.com",
                        Id = Guid.NewGuid()
                    };

                    if (user == null)
                    {
                        return StatusCode(500, "User Not found");
                    }
                    else
                    {
                        var claims = new List<Claim>() {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };

                        //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                        var principal = new ClaimsPrincipal(identity);
                        //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });
                        return StatusCode(StatusCodes.Status200OK);
                    }
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

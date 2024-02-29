using Application.Dtos;
using Application.Helpers;
using Core;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> SignInAsync(SignInDto model)
        {
            var user = _context.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
                return String.Empty;

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddMinutes(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpDto model)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                UserName = model.UserName,
                Position = model.Possition
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //kiểm tra role Customer đã có
                if (!await _roleManager.RoleExistsAsync(AppRole.Normal))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Normal));
                }

                await _userManager.AddToRoleAsync(user, AppRole.Normal);

                if (user.UserName == "ducle")
                {
                    if (!await _roleManager.RoleExistsAsync(AppRole.Administrator))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AppRole.Administrator));
                    }

                    await _userManager.AddToRoleAsync(user, AppRole.Administrator);
                }
            }

            return result;
        }
    }
}
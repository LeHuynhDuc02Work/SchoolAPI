using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Accounts
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpDto model);

        public Task<string> SignInAsync(SignInDto model);
    }
}
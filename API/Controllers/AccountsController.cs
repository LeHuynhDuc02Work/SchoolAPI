using Application.Accounts;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromForm] SignInDto signInDto)
        {
            return Ok(await _accountService.SignInAsync(signInDto));
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto signUpDto)
        {
            return Ok(await _accountService.SignUpAsync(signUpDto));
        }
    }
}

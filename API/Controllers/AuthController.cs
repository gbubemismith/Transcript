using System.Globalization;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized(new ApiResponse(401));

            var userDto = new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };

            return Ok(userDto);
        }

        [HttpPost("resgister")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                DisplayName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(registerDto.FirstName.ToLower() + " " + registerDto.LastName.ToLower())
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));


            return Ok(new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            });
        }
    }
}
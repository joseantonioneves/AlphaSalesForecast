using Microsoft.AspNetCore.Mvc;
using Repositories;
using WebAPIRequest.Models;
using Tokens;

namespace WebAPIRequest.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly JwtService? _jwtService;

        public AuthController (UserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // Aqui assumimos que você tem um método Authenticate que retorna um User
            var user = await _userRepository.Authenticate(loginModel.Username, loginModel.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            // Use o ID do usuário para gerar o token JWT
            var token = _jwtService.Generate(user.UserId);

            return Ok(new { token = token });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace udemy_dotnet_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserRequestDto request)
        {
            var response = await _authRepository.Register(
                new User{ Username = request.Username }, request.Password
            );

            if(!response.Success)
            {
                return BadRequest(response);
            }
            
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginUserRequestDto request)
        {
            var response = await _authRepository.Login(request.Username, request.Password);

            if(!response.Success)
            {
                return BadRequest(response);
            }
            
            return Ok(response);
        }
    }
}
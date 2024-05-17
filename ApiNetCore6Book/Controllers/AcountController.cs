using ApiNetCore6Book.Models;
using ApiNetCore6Book.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore6Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAccoutRepository _accoutRepository;

        public AcountController(IAccoutRepository accoutRepository)
        {
            _accoutRepository = accoutRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SigUpModel model)
        {
            var result = await _accoutRepository.SigUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded); 
            }

            return StatusCode(500); 
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SigIn(SigInModel model)
        {
            var result = await _accoutRepository.SigInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized(); 
            }
            return Ok(result); 
        }
    }
}

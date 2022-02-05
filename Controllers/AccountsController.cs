using AutoMapper;

namespace WebApplication1.Controllers
{
	[Route("api/accounts")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IMapper mapper;

		public AccountsController(UserManager<AppUser> _userManager, IMapper _mapper)
		{
			userManager = _userManager;
			mapper = _mapper;
		}
		[HttpPost("Registration")]
		public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
		{
			if (userForRegistration == null || !ModelState.IsValid)
			{
				return BadRequest();
			}

			var user = mapper.Map<AppUser>(userForRegistration);
			var result = await userManager.CreateAsync(user, userForRegistration.Password);

			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description);
				return BadRequest(new RegistrationResponseDto { Errors = errors });
			}
			return StatusCode(201);
		}
	}
}

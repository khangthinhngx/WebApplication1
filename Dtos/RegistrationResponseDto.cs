namespace WebApplication1.Dtos
{
	public class RegistrationResponseDto
	{
		public bool IsSuccessfulRegistration { get; set; }
		public IEnumerable<string> Errors { get; set; }
	}
}

namespace WebApplication1.Models
{
	public class Item
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		public string Date { get; set; } = DateTime.Now.ToString("F");
	}
}

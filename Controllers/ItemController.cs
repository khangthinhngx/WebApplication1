namespace WebApplication1.Controllers
{
	[Route("api/items")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly DataContext db;
		public ItemController(DataContext _db)
		{
			db = _db;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await db.Items.ToListAsync());
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			var item = await db.Items.FindAsync(Id);
			if (item == null)
			{
				return BadRequest("Not found!");
			}
			return Ok(item);
		}
		[HttpPost]
		public async Task<IActionResult> Post(Item item)
		{
			db.Items.Add(item);
			await db.SaveChangesAsync();
			return Ok(await db.Items.ToListAsync());
		}
		[HttpPut]
		public async Task<IActionResult> Put(Item _item)
		{
			var item = await db.Items.FindAsync(_item.Id);
			if (item == null)
			{
				return BadRequest("Not found!");
			}
			if (_item.Name != null)
			{
				item.Name = _item.Name;
			};
			if (_item.Content != null)
			{
				item.Content = _item.Content;
			}
			item.Date = DateTime.UtcNow.ToString("F");
			db.Items.Update(item);
			await db.SaveChangesAsync();
			return Ok(await db.Items.ToListAsync());
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var item = await db.Items.FindAsync(Id);
			if (item == null)
			{
				return BadRequest("Not found!");
			}
			db.Items.Remove(item);
			await db.SaveChangesAsync();
			return Ok();
		}
	}
}

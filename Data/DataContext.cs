namespace WebApplication1.Data
{
	public class DataContext : IdentityDbContext<AppUser>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			foreach (var entityType in builder.Model.GetEntityTypes())
			{
				var tableName = entityType.GetTableName();
				if (tableName.StartsWith("AspNet"))
				{
					entityType.SetTableName(tableName.Substring(6));
				}
			}
		}
		public DbSet<Item> Items { get; set; }
	}
}

using Microsoft.EntityFrameworkCore;

namespace Simple_Showcase.Data;
public class HousingContext : DbContext
{
	public DbSet<HouseEntity> Houses { get; set; }

	public string DBPath { get; }

	public HousingContext()
	{
		DBPath = "housing.db";
	}

	public void AddHouse(string adress, int rooms, int floorarea)
	{
		Houses.Add(new HouseEntity { Adress = adress, Rooms = rooms, FloorArea = floorarea });
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DBPath}");
}

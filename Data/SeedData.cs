using Microsoft.EntityFrameworkCore;
using SherconResort.Web.Models;

namespace SherconResort.Web.Data;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new ResortContext(serviceProvider.GetRequiredService<DbContextOptions<ResortContext>>()))
		{
			if (context.Rooms.Any())
			{
				return;
			}

			context.Rooms.AddRange(
				new Room
				{
					Name = "Kubo Single",
					AccomodationType = "Daytour",
					RoomType = "Kubo",
					MaxOccupants = 6,
					Price = 1000.00M
				},
				new Room
				{
					Name = "Kubo Twin",
					AccomodationType = "Daytour",
					RoomType = "Kubo",
					MaxOccupants = 12,
					Price = 2000.00M
				},
				new Room
				{
					Name = "Kubo Family",
					AccomodationType = "Daytour",
					RoomType = "Kubo",
					MaxOccupants = 20,
					Price = 2500.00M
				},
				new Room
				{
					Name = "Bougainvillea Benches",
					AccomodationType = "Daytour",
					RoomType = "Benches",
					MaxOccupants = 6,
					Price = 2500.00M
				},
				new Room
				{
					Name = "Japanese Kubo",
					AccomodationType = "Daytour",
					RoomType = "Kubo",
					MaxOccupants = 6,
					Price = 1000.00M
				}
			);

			context.SaveChanges();
		}
	}
}
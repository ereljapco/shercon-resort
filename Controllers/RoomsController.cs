using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SherconResort.Web.Data;
using SherconResort.Web.Models;


namespace SherconResort.Web.Controllers;

public class RoomsController : Controller
{
	private readonly ResortContext _context;

	public RoomsController(ResortContext context)
	{
		_context = context;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _context.Rooms.ToListAsync());
	}

	public async Task<IActionResult> Main()
	{
		return View(await _context.Rooms.ToListAsync());
	}

	public ActionResult Add()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Add([Bind("Name, Description, AccomodationType, RoomType, MaxOccupants, NumberofBedrooms, NumberOfBeds, NumberOfBathRooms, HasKitchen, HasAircon, Price")] Room room)
	{
		try
		{
			if (ModelState.IsValid)
			{
				room.CreateAt = DateTime.Now;
				room.UpdatedAt = DateTime.Now;

				_context.Add(room);
				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Main));
			}
		}
		catch (DbUpdateException)
		{
			ModelState.AddModelError("", "Unable to save changes. " +
						"Try again, and if the problem persists " +
						"see your system administrator.");
		}

		return View(room);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var room = await _context.Rooms.FirstOrDefaultAsync(room => room.Id == id);

		if (room == null)
		{
			return NotFound();
		}

		return View(room);
	}

	[HttpPost, ActionName("Edit")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var roomToUpdate = await _context.Rooms.FirstOrDefaultAsync(room => room.Id == id);

		if (roomToUpdate == null)
		{
			return NotFound();
		}

		if (await TryUpdateModelAsync<Room>(
			roomToUpdate,
			"",
			room => room.Name,
			room => room.Description,
			room => room.AccomodationType,
			room => room.RoomType,
			room => room.MaxOccupants,
			room => room.NumberofBedrooms,
			room => room.NumberOfBeds,
			room => room.NumberOfBathRooms,
			room => room.HasKitchen,
			room => room.HasAircon,
			room => room.UpdatedAt
		))
		{
			try
			{
				roomToUpdate.UpdatedAt = DateTime.Now;

				await _context.SaveChangesAsync();

				return RedirectToAction(nameof(Main));
			}
			catch (DbUpdateException)
			{
				ModelState.AddModelError("", "Unable to save changes. " +
								"Try again, and if the problem persists, " +
								"see your system administrator.");
			}
		}

		return View(roomToUpdate);
	}

	public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
	{
		if (id == null)
		{
			return NotFound();
		}

		var room = await _context.Rooms
			.AsNoTracking()
			.FirstOrDefaultAsync(room => room.Id == id);

		if (room == null)
		{
			return NotFound();
		}

		if (saveChangesError.GetValueOrDefault())
		{
			ViewData["ErrorMessage"] = "Delete failed. Please try again.";
		}

		return View(room);
	}

	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Delete(int id)
	{
		var room = await _context.Rooms.FindAsync(id);

		if (room == null)
		{
			return RedirectToAction(nameof(Main));
		}

		try
		{
			_context.Rooms.Remove(room);

			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Main));
		}
		catch (DbUpdateException)
		{
			return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
		}
	}

}

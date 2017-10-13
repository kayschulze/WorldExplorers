using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldExplorer.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldExplorer.Controllers
{
	public class LocationsController : Controller
	{
		private WorldExplorersContext db = new WorldExplorersContext();

		public IActionResult Index()
		{
		    return View(db.Locations.ToList());
		}

		public IActionResult Details(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
			return View(thisLocation);
		}

		public IActionResult Create()
		{
			//ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Location location)
		{
			db.Locations.Add(location);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(location => location.LocationId == id);
			//ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
			return View(thisLocation);
		}

		[HttpPost]
		public IActionResult Edit(Location location)
		{
			db.Entry(location).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
			return View(thisLocation);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
			db.Locations.Remove(thisLocation);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

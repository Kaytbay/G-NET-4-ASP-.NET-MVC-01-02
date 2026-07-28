using GymSys.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GymSys.Controllers
{
    public class PlansController : Controller
    {
        private readonly GymDbContext dbContext;

        public PlansController()
        {
            dbContext = new GymDbContext();
        }

        public async Task<IActionResult> Index()
        {
            var Plans =await dbContext.Plans.ToListAsync();

            return View(Plans);
        }

        public async Task<IActionResult> Details(int id)
        {
            var plan = await dbContext.Plans.FindAsync(id);

            if (plan == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

         
    }
}

using GymSys.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

         
    }
}

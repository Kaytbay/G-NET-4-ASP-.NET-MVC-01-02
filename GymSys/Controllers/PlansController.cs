using GymSys.DAL.Repositories.Classes;
using GymSys.DAL.Repositories.Interfasec;
using GymSys.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GymSys.Controllers
{
    public class PlansController : Controller
    {
        // private readonly GymDbContext dbContext;
        //public PlansController()
        //{
        //    dbContext = new GymDbContext();
        //}


        private readonly IPlanRepository _planRepository;

         public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var Plans= await  _planRepository.GetAllAsync(ct: ct);

            return View(Plans);
        }

        public async Task<IActionResult> Details(int id , CancellationToken ct)
        {
            var plan = await _planRepository.GetByIdAsync(id,ct);

            if (plan == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

         
    }
}

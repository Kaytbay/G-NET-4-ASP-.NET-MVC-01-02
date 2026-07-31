using GymSys.DAL.Repositories.Interfasec;
using GymSys.DbContexts;
using GymSys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSys.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {

        readonly GymDbContext _dbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddAsync(Plan plan, CancellationToken ct = default)
        {
             _dbContext.Plans.AddAsync(plan, ct);
            return  await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default)
        {
            _dbContext.Plans.Remove(plan);
            return await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken ct = default)
        {
            //if(tracking) {
            //    return await _dbContext.Plans.ToListAsync(ct);
            //}
            //else {
            //    return await _dbContext.Plans.AsNoTracking().ToListAsync(ct);
            //}

            IQueryable<Plan> query = tracking? _dbContext.Plans : _dbContext.Plans.AsNoTracking();

            return await query.ToListAsync(ct);
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync(id, ct);
        }

        public Task<int> UpdateAsync(Plan plan, CancellationToken ct = default)
        {
           _dbContext.Plans.Update(plan);
            return _dbContext.SaveChangesAsync(ct);
        }
    }
}

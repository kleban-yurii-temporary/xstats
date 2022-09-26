using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace XStats.Repos
{
    public class LossesRepository
    {
        private readonly XStatsContext _ctx;

        public LossesRepository(XStatsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<DailyLosses>> GetDailyAsync(string date = null)
        {
            var maxDate = _ctx.DailyLosses.Max(x => x.Date);
            return await _ctx.DailyLosses.Include(x => x.Type).OrderBy(x => x.Type.Order).Where(x => x.Date == maxDate).ToListAsync();
        }
    }
}

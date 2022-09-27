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
            var maxDate = await GetMaxDateAsync();
            var losses = await _ctx.DailyLosses.Include(x => x.Type).OrderBy(x => x.Type.Order).Where(x => x.Date == maxDate).ToListAsync();
            var dataBefore = _ctx.DailyLosses.Include(x => x.Type).Where(x => x.Date == maxDate.Value.AddDays(-1)).ToList();

            for(int i = 0; i < losses.Count; i++)
            {
                losses[i].CountPlus = losses[i].Count - dataBefore[i].Count;
            }

            return losses;
        }

        public async Task<DateTime?> GetMaxDateAsync()
        {
            return await _ctx.DailyLosses.MaxAsync(x => x.Date);
        }

        public async Task<KeyValuePair<List<string>, List<int>>> GetLossesDataByTypeAsync(int id)
        {
            var data = await _ctx.DailyLosses.Where(x => x.Type.Id == id).
                OrderByDescending(x => x.Date).Take(15).OrderBy(x => x.Date).ToListAsync();

            return new KeyValuePair<List<string>, List<int>>(
                data.Select(x => "d" + x.Date.Value.ToString("ddMMyyyy")).ToList(),
                data.Select(x => x.Count).ToList());
        }
    }
}

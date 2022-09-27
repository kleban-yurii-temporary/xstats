using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStats.Core;

namespace XStats.Repos
{
    public class EqRepository
    {
        private readonly XStatsContext _ctx;

        public EqRepository(XStatsContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<EquipmentType?> GetTypeByIdAsync(int id)
        {
            return await _ctx.EquipmentTypes.FindAsync(id);
        }
    }
}

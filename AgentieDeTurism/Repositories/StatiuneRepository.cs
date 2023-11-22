using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories
{
    public class StatiuneRepository : RepositoryBase<Statiune>, IStatiuneRepository
    {
        public StatiuneRepository(Context context)
           : base(context)
        {
        }

        public Statiune FindById(int id)
        {
            Statiune statiune= FindByCondition(statiune=>statiune.ID==id).ToList()[0];
            return statiune;
        }
    }
}

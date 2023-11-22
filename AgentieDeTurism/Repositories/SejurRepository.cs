using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories
{
    public class SejurRepository : RepositoryBase<Sejur>, ISejurRepository
    {
        public SejurRepository(Context context) : base(context)
        {
        }

        public ICollection<Sejur> FindByID(int id)
        {
            var query = FindByCondition(sejur => sejur.StatiuneID == id);
            ICollection<Sejur> sejururi = query.ToList();

            return sejururi;
        }
    }
}

using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories
{
    public class RezervareRepository : RepositoryBase<Rezervare>, IRezervareRepository
    {
        public RezervareRepository(Context context)
           : base(context)
        { }

        public ICollection<Rezervare> FindByID(int ID)
        {
            var query = FindByCondition(rezervare => rezervare.ClientID == ID);
            ICollection<Rezervare> rezervari = query.ToList();

            return rezervari;
        }
    }
}

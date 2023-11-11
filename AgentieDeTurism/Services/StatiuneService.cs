using AgentieDeTurism.Repositories.Interfaces;
using AgentieDeTurism.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services
{
    public class StatiuneService:IStatiuneService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatiuneService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}

using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Services
{
    public class StatiuneService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatiuneService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
    }
}

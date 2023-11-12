using AgentieDeTurism.Models;
using AgentieDeTurism.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Context _context;
        private IClientRepository _clientRepository;

        private IStatiuneRepository _statiuneRepository;

        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_context);
                }
                return _clientRepository;
            }
        }

        public IStatiuneRepository StatiuneRepository
        {
            get
            {
                if (_statiuneRepository == null)
                {
                    _statiuneRepository = new StatiuneRepository(_context);
                }
                return _statiuneRepository;
            }
        }

        public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

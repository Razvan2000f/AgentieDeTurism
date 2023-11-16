using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IClientRepository ClientRepository { get; }
        IStatiuneRepository StatiuneRepository { get; }
        ISejurRepository SejurRepository { get; }

        void Save();
    }
}

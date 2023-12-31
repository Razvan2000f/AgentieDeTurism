﻿using AgentieDeTurism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories.Interfaces
{
    public interface ISejurRepository : IRepositoryBase<Sejur>
    {
        ICollection<Sejur> FindByID(int id);
    }
}

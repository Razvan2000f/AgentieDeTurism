﻿using AgentieDeTurism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentieDeTurism.Repositories.Interfaces
{
    public interface IStatiuneRepository : IRepositoryBase<Statiune>
    {
        Statiune FindById(int id);
    }
}

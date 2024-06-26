﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IClinicListManager : IManager<ClinicList>
    {
        public Task<bool> CreateClinicToListAsync(ClinicList clinicList);
    }
}

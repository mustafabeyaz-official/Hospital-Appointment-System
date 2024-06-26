﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Abstracts
{
    public interface IDoctorManager : IManager<Doctor>
    {
        public Task<bool> CreateDoctorAsync(Doctor doctor);
    }
}

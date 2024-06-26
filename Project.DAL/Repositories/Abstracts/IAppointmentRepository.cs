﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public Task<bool> AddAppointmentAsync(Appointment appointment);
    }
}

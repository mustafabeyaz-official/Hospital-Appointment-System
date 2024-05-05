using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Appointment : BaseEntity
    {
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public DateTime AppointmentDate { get; set; }

        //Relational Properties
        public Doctor Doctor { get; set; }
        public User User { get; set; }
    }
}

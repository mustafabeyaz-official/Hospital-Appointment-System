using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int ClinicID { get; set; }

        //Relatioanl Properties
        public List<Appointment> Appointments { get; set; }
        public Clinic Clinic { get; set; }
    }
}

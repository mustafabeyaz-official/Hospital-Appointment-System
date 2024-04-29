using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Clinic : BaseEntity
    {
        public string ClinicName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public List<ClinicList> ClinicLists { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}

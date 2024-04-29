using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class ClinicList : BaseEntity
    {
        public int ClinicID { get; set; }
        public int HospitalID { get; set; }

        //Relational Properties
        public Clinic Clinic { get; set; }
        public Hospital Hospital { get; set; }
    }
}

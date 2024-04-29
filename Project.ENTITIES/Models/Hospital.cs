using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Hospital : BaseEntity
    {
        public string HospitalName { get; set; }
        public string Address { get; set; }

        //Relational Properties
        public List<ClinicList> ClinicLists { get; set; }
    }
}

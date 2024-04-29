using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
    public class DoctorConfiguration : BaseConfiguration<Doctor>
    {
        public override void Configure(EntityTypeBuilder<Doctor> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Clinic).WithMany(x => x.Doctors)
                .HasForeignKey(x => x.ClinicID);
        }
    }
}

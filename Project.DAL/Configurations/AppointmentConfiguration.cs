using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
    public class AppointmentConfiguration : BaseConfiguration<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Doctor).WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorID);
            builder.HasOne(x => x.User).WithMany(x => x.Appointments)
                .HasForeignKey(x => x.UserID);
        }
    }
}

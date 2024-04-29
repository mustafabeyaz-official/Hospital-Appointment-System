using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
    public class ClinicConfiguration : BaseConfiguration<Clinic>
    {
        public override void Configure(EntityTypeBuilder<Clinic> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.ClinicLists).WithOne(x => x.Clinic)
                .HasForeignKey(x => x.ClinicID);
        }
    }
}

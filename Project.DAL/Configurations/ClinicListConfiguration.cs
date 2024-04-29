using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
    public class ClinicListConfiguration : BaseConfiguration<ClinicList>
    {
        public override void Configure(EntityTypeBuilder<ClinicList> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.ClinicID,
                x.HospitalID
            });
        }
    }
}

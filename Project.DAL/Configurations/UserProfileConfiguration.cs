using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Configurations
{
    public class UserProfileConfiguration : BaseConfiguration<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.User).WithOne(x => x.Profile)
                .HasForeignKey<UserProfile>(x => x.ID);
        }
    }
}

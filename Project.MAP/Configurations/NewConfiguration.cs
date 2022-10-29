using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
    public class NewConfiguration : BaseConfiguration<New>
    {
        public override void Configure(EntityTypeBuilder<New> builder)
        {
            base.Configure(builder);
        }
    }
}

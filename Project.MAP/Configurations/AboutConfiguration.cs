using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
	public class AboutConfiguration : BaseConfiguration<About>
	{
		public override void Configure(EntityTypeBuilder<About> builder)
		{
			base.Configure(builder);
		}
	}
}

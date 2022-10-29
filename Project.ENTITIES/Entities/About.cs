using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
	public class About : BaseEntity , IEntity
	{
		public string History { get; set; }
		public string AboutUs { get; set; }
	
		//Relational Properties
	}
}

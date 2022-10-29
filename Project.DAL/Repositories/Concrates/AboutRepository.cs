using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrates
{
	public class AboutRepository : BaseRepository<About> , IAboutRepository
	{
		public AboutRepository(MyContext db) : base(db)
		{

		}
	}
}

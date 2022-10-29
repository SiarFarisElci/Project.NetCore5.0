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
    public class ServiceRepository : BaseRepository<Service> , IServiceRepository
    {
        public ServiceRepository(MyContext db) : base(db)
        {

        }
    }
}

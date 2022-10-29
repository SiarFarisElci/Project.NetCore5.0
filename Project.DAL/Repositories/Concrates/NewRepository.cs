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
    public class NewRepository : BaseRepository<New> , INewRepository
    {
        public NewRepository(MyContext db) : base(db)
        {

        }
    }
}

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
    public class TeamRepository : BaseRepository<Team>  , ITeamRepository
    {
        public TeamRepository(MyContext db) : base(db)
        {

        }
    }
}

using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concrates
{
    public class TeamManager : BaseManager<Team> , ITeamManager
    {
        ITeamRepository _tRep;

        public TeamManager(ITeamRepository tRep) : base(tRep)
        {
            _tRep = tRep;
        }
    }
}

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
    public class NewManager : BaseManager<New> , INewManager
    {
        INewRepository _nRep;

        public NewManager(INewRepository nRep) : base(nRep)
        {
            _nRep = nRep;
        }
    }
}

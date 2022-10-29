using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class Contact : BaseEntity , IEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Message { get; set; }

        //Relational Properties

    }
}

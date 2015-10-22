using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTemple.Data.Repositories;

namespace eTemple.Data.Models
{
    public partial class rolemodulemappings : IEntity
    {

        public int Id { get; set; }

        public string Module { get; set; }

        public int Role { get; set; }

        public int Entitlement { get; set; }

    }
}

using MariaWebApp.Data.Base;
using MariaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data.Services
{
    public class OrganenService :EntityBaseRepository<Organ> ,IOrganenService
    {
        public OrganenService(ApplicationDbContext context) : base(context) { }
        
    }
}

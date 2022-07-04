using MariaWebApp.Data.Base;
using MariaWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data.Services
{
    public class PersonenService : EntityBaseRepository<Person> ,IPersonenService
    {    
        public PersonenService(ApplicationDbContext context) : base(context) { }
      
    }
}


   


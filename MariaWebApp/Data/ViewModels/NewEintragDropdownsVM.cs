using MariaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data.ViewModels
{
    public class NewEintragDropdownsVM
    {
        public NewEintragDropdownsVM()
        {
            Personen = new List<Person>();
        }

        public List<Person>Personen { get; set; }
        
        

    }
}

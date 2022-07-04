using MariaWebApp.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Models
{
  
    public class Person_Eintrag
    {
        [Display(Name = "PersonId")]
        public int PersonId{ get; set; }
        [ForeignKey("PersonId")]


        [Display(Name = "EintragId")]
        public int EintragId { get; set; }
        [ForeignKey("EintragId")]

        public Eintrag Einträge { get; set; }
        public Person  Personen    { get; set; }


        
    }
}

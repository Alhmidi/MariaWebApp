using MariaWebApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Models
{
    public class NewEintragVM
    {

        public int Id { get; set; }

        [Display(Name = "Datum")]
        [Required(ErrorMessage = "Bitte Datum eingeben")]  
        public DateTime CreateDatetime { get; set; }
        

        [Display(Name = "Inhalt")]
        public string EintragInhalt { get; set; }

        public List<Person_Eintrag> Personen_Einträge { get; set; }


        //Relation

        [Display(Name = "Select Personen")]
        [Required(ErrorMessage = "Bitte PersonId eingeben")]
        public List<int> PersonIds { get; set; }

      



    }
}

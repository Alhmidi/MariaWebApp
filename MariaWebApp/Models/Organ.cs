using MariaWebApp.Data;
using MariaWebApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Models
{
    public class Organ: IEntityBase
    {  
        
        [Display (Name="Id")]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "bitte Name eingeben")]
        [Display(Name = "Name")]
        [MaxLength(50)]

        public string Name { get; set; }

        [Display(Name = "Logo")]

        public string Logo { get; set; }

        [Display(Name = "Straße")]
        [MaxLength(50)]

        public string Strasse { get; set; }

        [Display(Name = "PLZ")]
        [MaxLength(30)]

        public string PLZ { get; set; }

        [Display(Name = "Ort")]
        [MaxLength(50)]

        public string Ort { get; set; }

        [Display(Name = "Land")]
        [MaxLength(50)]

        public string Land { get; set; }

        [Display(Name = "TEL")]
        [MaxLength(100)]

        public string Telefon { get; set; }

        [Display(Name = "EMail")]
        [MaxLength(200)]

        public string eMail { get; set; }

        [Display(Name = "Beschreibung")]
        [MaxLength(200)]

        public string Beschreibung { get; set; }

        [Required(ErrorMessage="bitte Kategorie eingeben")]
        [Display(Name = "Cateory")]
        
        public OrganCategory OrganCategory { get; set; }

        // ------ Relation ----

     
        public List<Person> Personen { get; set ; }

       
    }
}

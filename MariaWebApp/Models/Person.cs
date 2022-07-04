using MariaWebApp.Data;
using MariaWebApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Models
{
    public class Person :IEntityBase
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Required(ErrorMessage = "bitte Vorname eingeben")]
        [Display(Name = "Vorname")] 
        [MaxLength(50)]public string Vorname { get; set; }

        [Required(ErrorMessage = "bitte Nachname eingeben")]
        [Display(Name = "Nachname")]
        [MaxLength(50)]
        public string Nachname { get; set; }

       
        [Display(Name = "Straße")]
        [MaxLength(100)]
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


        [Display(Name = "Telefon")]
        [MaxLength(50)]
        public string Telefon { get; set; }


        [Display(Name = "EMail")]
        [MaxLength(200)]
        public string eMail { get; set; }


        [Display(Name = "Bemerkung")]

        [MaxLength(200)]
        public string Bemerkung { get; set; }


        [Required(ErrorMessage = "bitte  Kategorie eingeben")]
        [Display(Name = "Category")]
        public  PersonCategory PersonCategory { get; set; }

        //-----Relation--------
      
        public List<Person_Eintrag>Personen_Einträge{get; set;}

        [Required(ErrorMessage = "bitte  OrganId eingeben")]
        public int OrganId { get; set; }
        [ForeignKey("OrganId")]


        // Relation
        public Organ Organ { get; set; }
    }
}

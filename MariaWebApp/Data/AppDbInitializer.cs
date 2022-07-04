using MariaWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data
{
    public class AppDbInitializer
    {
        public static void Seed( IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                // Organ

                if(!context.Organ.Any())
                {
                    context.Organ.AddRange(new List<Organ>()
                    {
                        new Organ()
                        {
                            Name="Organ1",
                          
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort=" Ort ",
                            Land="Land ",
                            Telefon="11111111",
                            eMail="Organ1@Organ.de",
                            Beschreibung="das ist Ogan1",
                            OrganCategory=OrganCategory.Firma
                        },  new Organ()
                        {
                             Name="Organ2",
                            
                            Strasse= "Strasse 2",
                            PLZ="00002",
                            Ort="Ort",
                            Land="Land ",
                            Telefon="2222222",
                            eMail="Organ2@ Organ.de",
                            Beschreibung="das ist das Ogan2",
                            OrganCategory=OrganCategory.Firma
                        },
                        new Organ()
                        {
                            Name ="Organ3",
                            
                            Strasse = "Strasse",
                            PLZ = "00001",
                            Ort = "Ort ",
                            Land = "Land ",
                            Telefon = "3333333",
                            eMail = "Organ3@ Organ.de",
                            Beschreibung = "das ist Ogan3",
                            OrganCategory = OrganCategory.Firma
                         },
                         new Organ()
                         {
                            Name = "Organ4",
                            
                            Strasse = "Strasse",
                            PLZ = "00003",
                            Ort = "Ort",
                            Land = "Land",
                            Telefon = "4444444",
                            eMail = "Organ4@ Organ.de",
                            Beschreibung = "das ist Ogan4",
                            OrganCategory = OrganCategory.Schule
                         },
                         new Organ()
                         {
                            Name = "Organ5",
                            
                            Strasse = "Strasse",
                            PLZ = "00002",
                            Ort = "Ort",
                            Land = "Land",
                            Telefon = "5555555",
                            eMail = "Organ5@ organ.de" ,
                            Beschreibung = "das ist Ogan5",
                            OrganCategory = OrganCategory.Schule
                         },
                         new Organ()
                         {
                            Name = "Organ6",
                            
                            Strasse = "Strasse",
                            PLZ = "00003",
                            Ort = "Ort",
                            Land = "Land",
                            Telefon = "6666666",
                            eMail = "Organ6@Organ.de",
                            Beschreibung = "das ist Ogan6",
                            OrganCategory = OrganCategory.Schule
                         },
                         new Organ()
                         {
                            Name = "Maria",
                            Strasse = "Strasse",
                            PLZ = "00000",

                            Ort = "Ort",
                            Land = "Land",
                            Telefon = "000000",
                            eMail = "Maria@maria.de",
                            Beschreibung = "das ist die Beratungsfirma",
                            OrganCategory = OrganCategory.Andere
                         },
                    });
                    context.SaveChanges();
                }
                        

                //Person
                if (!context.Person.Any())
                {
                    context.Person.AddRange(new List<Person>()
                    {
                        new Person()
                        {

                          
                            Vorname="Schüler1",
                            Nachname="Nachname",
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="11111111",
                            eMail="schüler1@schüle.de",
                            Bemerkung="das ist schüle 1",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 4
                        },
                        new Person()
                        {
                           
                            Vorname="Schüler2",
                            Nachname="Namchname",
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="2222222",
                            eMail="schüler2@schüle.de",
                            Bemerkung="das ist schüle 2",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 5
                        },
                        new Person()
                        {

                            
                            Vorname="Schüler3",
                            Nachname="Nachname",
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="3333333",
                            eMail="schüler3@schüle.de",
                            Bemerkung="das ist schüle 1",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 6
                       
                         },
                        new Person()
                        {


                            Vorname="Schüler4",
                            Nachname="Nachname",
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="444444",
                            eMail="schüler4@schüle.de",
                            Bemerkung="das ist schüle 4",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 4

                         },
                         new Person()
                         {


                            Vorname="Schüler5",
                            Nachname="Nachname",
                            Strasse= "Strasse",
                            PLZ="00001",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="555555",
                            eMail="schüler5@schüle.de",
                            Bemerkung="das ist schüle 5",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 5

                         },
                         new Person()
                         {


                            Vorname="Schüler6",
                            Nachname="Nachname",
                            Strasse= "Strasse",
                            PLZ="00003",
                            Ort="Ort ",
                            Land="Land ",
                            Telefon="666666",
                            eMail="schüler6@schüle.de",
                            Bemerkung="das ist schüle6 ",
                            PersonCategory=PersonCategory.Schüler,
                            OrganId= 6

                         },
                        new Person()
                        {
                           
                            Vorname = "Ausbilder1",
                            Nachname = "Nachname",
                            //Strasse = " Strasse",
                            //PLZ = " 00001",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "11111111",
                            eMail = "ausbilder1@ausbilder.de",
                            Bemerkung = "das ist Ausbilder1",
                            PersonCategory = PersonCategory.Ausbilder,
                            OrganId = 1
                        },
                        new Person()
                        {
                           
                            Vorname = "Ausbilder2",
                            Nachname = "Nachname",
                            Strasse = "Strasse",
                            //PLZ = " 00001",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "22222222",
                            eMail = "ausbilder2@ausbilder.de",
                            Bemerkung = "das ist Ausbilder2",
                            PersonCategory = PersonCategory.Ausbilder,
                           OrganId = 2
                        },
                        new Person()
                        {
                           
                            Vorname = "Ausbilder3",
                            Nachname = "Nachname",
                            Strasse = "Strasse",
                            //PLZ = " 00003",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "3333333",
                            eMail = "ausbilder3@ausbilder.de",
                            Bemerkung = "das ist Ausbilder3",
                            PersonCategory = PersonCategory.Ausbilder,
                            OrganId = 3
                        },
                        new Person()
                        {

                            Vorname = "Ausbilder4",
                            Nachname = "Nachname",
                            //Strasse = " Strasse",
                            //PLZ = " 00003",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "4444444",
                            eMail = "ausbilder4@ausbilder.de",
                            Bemerkung = "das ist Ausbilder4",
                            PersonCategory = PersonCategory.Ausbilder,
                            OrganId = 1
                        },
                        new Person()
                        {

                            Vorname = "Ausbilder5",
                            Nachname = "Nachname",
                            //Strasse = " Strasse",
                            //PLZ = " 00002",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "555555",
                            eMail = "ausbilder5@ausbilder.de",
                            Bemerkung = " das ist Ausbilder5",
                            PersonCategory = PersonCategory.Ausbilder,
                            OrganId= 2
                        },
                        new Person()
                        {

                            Vorname = "Ausbilder6",
                            Nachname = "Nachname",
                            //Strasse = " Strasse",
                            //PLZ = " 00001",
                            //Ort = " Ort ",
                            //Land = " Land ",
                            Telefon = "666666",
                            eMail = "ausbilder6@ausbilder.de",
                            Bemerkung = "das ist Ausbilder6",
                            PersonCategory = PersonCategory.Ausbilder,
                             OrganId = 3
                        },
                        
                        new Person()
                        {

                            Vorname = "Mitarbeiter1",
                            Nachname = "Nachname",
                            Strasse = " Strasse",
                            PLZ = "00001",
                            Ort = "Ort ",
                            Land = "Land ",
                            Telefon = "11111111",
                            eMail = "Mitarbeier1@Mitarbeiter.de",
                            Bemerkung = "das ist Mitarbeiter1",
                            PersonCategory = PersonCategory.Mitarbeiter,
                            OrganId=7
                            
                        },
                        new Person()
                        {

                            Vorname = "Mitarbeiter2",
                            Nachname = "Nachname",
                            Strasse = " Strasse",
                            PLZ = "00002",
                            Ort = "Ort ",
                            Land = "Land ",
                            Telefon = "2222222",
                            eMail = "Mitarbeier2@Mitarbeiter.de",
                            Bemerkung = "das ist Mitarbeiter2",
                            PersonCategory = PersonCategory.Mitarbeiter,
                            OrganId=7
                        },
                        new Person()
                        {

                            Vorname = "Mitarbeiter3",
                            Nachname = "Nachname",
                            Strasse = "Strasse",
                            PLZ = "00003",
                            Ort = "Ort ",
                            Land = "Land ",
                            Telefon = "3333333",
                            eMail = "Mitarbeier3@Mitarbeiter.de",
                            Bemerkung = "das ist Mitarbeiter3",
                            PersonCategory = PersonCategory.Mitarbeiter,
                            OrganId=7
                        },
                        new Person()
                        {

                            Vorname = "Mitarbeiter4",
                            Nachname = "Nachname",
                            Strasse = "Strasse",
                            PLZ = "00001",
                            Ort = "Ort ",
                            Land = "Land ",
                            Telefon = "4444444",
                            eMail = "Mitarbeier1@mitarbeiter.de",
                            Bemerkung = "das ist Mitarbeiter4",
                            PersonCategory = PersonCategory.Mitarbeiter,
                            OrganId=7
                        },

                    });
                    context.SaveChanges();

                }

                //Eintag
                if (!context.Eintrag.Any())
                {
                    context.AddRange(new List<Eintrag>()
                    {
                        new Eintrag()
                        {
                            CreateDatetime=DateTime.Now.AddDays(-4),
                            EintragInhalt="Eintrag1 "

                        },
                        new Eintrag()
                        {
                            CreateDatetime=DateTime.Now.AddDays(-3),
                            EintragInhalt="Eintrag2"

                        },
                        new Eintrag()
                        {
                            CreateDatetime=DateTime.Now.AddDays(-2),
                            EintragInhalt="Eintrag3"

                        },
                        new Eintrag()
                        {
                            CreateDatetime=DateTime.Now.AddDays(-1),
                            EintragInhalt="Eintrag4"

                        },                
                    });
                    context.SaveChanges();
                }

                //Personen & Einträge
                if (!context.Person_Eintrag.Any())
                {
                    context.AddRange(new List<Person_Eintrag>()
                    {
                        new Person_Eintrag()
                        {
                            EintragId=1,
                            PersonId=1
                        },
                        new Person_Eintrag()
                        {
                            EintragId=1,
                           PersonId=7
                        },
                        new Person_Eintrag()
                        {
                            EintragId=1,
                            PersonId=13
                        },
                        new Person_Eintrag()
                        {
                            EintragId=2,
                            PersonId=2
                        },
                        new Person_Eintrag()
                        {
                            EintragId=2,
                            PersonId=8
                        },
                        new Person_Eintrag()
                        {
                            EintragId=2,
                            PersonId=14
                        },
                        new Person_Eintrag()
                        {
                            EintragId=3,
                            PersonId=3
                        },
                        new Person_Eintrag()
                        {
                            EintragId=3,
                            PersonId=8
                        },
                        new Person_Eintrag()
                        {
                            EintragId=3,
                            PersonId=14
                        },
                         new Person_Eintrag()
                        {
                            EintragId=4,
                            PersonId=4
                        },
                        new Person_Eintrag()
                        {
                            EintragId=4,
                            PersonId=9
                        },
                        new Person_Eintrag()
                        {
                            EintragId=4,
                            PersonId=15
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

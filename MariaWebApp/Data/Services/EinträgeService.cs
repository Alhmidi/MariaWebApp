using MariaWebApp.Data.Base;
using MariaWebApp.Data.ViewModels;
using MariaWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Data.Services
{
  
    public class EinträgeService : EntityBaseRepository<Eintrag> ,IEinträgeService
    {
        private readonly ApplicationDbContext _context;


        public EinträgeService(ApplicationDbContext context) : base(context)
        { 
            _context = context; 
        }

        public async Task AddNewEintragAsync(NewEintragVM data)
        {
            var newEintrag = new Eintrag()
            {
                CreateDatetime = data.CreateDatetime,
                EintragInhalt = data.EintragInhalt,
            };
               await _context.Eintrag.AddAsync(newEintrag);
               await _context.SaveChangesAsync();

            // Add Person_Eintrag
            foreach( var personId in data.PersonIds)
            {
                var newPersonEintrag = new Person_Eintrag()
                {
                    EintragId = newEintrag.Id,
                    PersonId = personId
                };
                 await _context.Person_Eintrag.AddAsync(newPersonEintrag);                
            }
             await _context.SaveChangesAsync();
        }

        public async Task<Eintrag>GetEintragByIdAsync(int id)
        {
            var eintragDetails = await _context.Eintrag
                .Include(pe => pe.Personen_Einträge).ThenInclude(p=> p.Personen)
                .FirstOrDefaultAsync(n => n.Id == id);
                return  eintragDetails;
        }

        public async Task<NewEintragDropdownsVM> GetNewEintragDropdownsValues()
        {
            
                var response = new NewEintragDropdownsVM()
              { Personen = await _context.Person.OrderBy(n => n.Vorname).ToListAsync()};
            
                 return response;
        }

       
    

        public async Task UpdateEintraAsync(NewEintragVM data)
        {
            var dbEintrag = await _context.Eintrag.FirstOrDefaultAsync( n => n.Id == data.Id);

            if ( dbEintrag != null)
            {
                dbEintrag.CreateDatetime = data.CreateDatetime;
                dbEintrag.EintragInhalt = data.EintragInhalt;
                await _context.SaveChangesAsync();
            }
            // Remove existing Einträge
            var existingEinträgeDb = _context.Person_Eintrag.Where(n => n.EintragId == data.Id).ToList();
             _context.Person_Eintrag.RemoveRange(existingEinträgeDb);
             await _context.SaveChangesAsync();

            // Add PersonEintrag
            foreach( var  personId in data.PersonIds)
            {
                var newPersonEintrag = new Person_Eintrag()
                {
                    EintragId = data.Id,
                    PersonId = personId
                }; await _context.Person_Eintrag.AddAsync(newPersonEintrag);
            }
            await _context.SaveChangesAsync();
        }

       


    }
        

}

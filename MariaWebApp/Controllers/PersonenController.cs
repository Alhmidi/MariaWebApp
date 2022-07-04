using MariaWebApp.Data;
using MariaWebApp.Data.Services;
using MariaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Controllers
{
    public class PersonenController : Controller

    {
        private readonly IPersonenService _service;

        public PersonenController( IPersonenService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n=>n.Organ);

            return View(data);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allPersonen = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allPersonen.Where
                (n => string.Equals(n.Vorname, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Nachname, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Strasse, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Land, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Id.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();


                return View("Index", filteredResultNew);
            }

               return View("Index", allPersonen);
        }



        // Get : Personen/ Create
        public IActionResult Create()
        {
            return View();        
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind()] Person person)
        {
            if(!ModelState.IsValid)
            {
                return View(person);
            }
            await _service.AddAsync(person);
            return RedirectToAction(nameof(Index));
        }
       
        // Get : Personen/Details/1

        public async Task<IActionResult> Details( int Id)
        {
            var personDetails = await _service.GetByIdAsync(Id);

            if(personDetails== null)  return View("nicht gefunden");       
         
            return View(personDetails);
        }

        // Get : Personen/ Edit/1
        public  async Task< IActionResult>Edit( int Id)
        {
            var personDetails = await _service.GetByIdAsync(Id);

            if (personDetails == null) return View("nicht gefunden");


            return View(personDetails);
        }


        [HttpPost]
        public async Task<IActionResult>Edit( int Id,[Bind()] Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            await _service.UpdateAsync( Id ,person);
            return RedirectToAction(nameof(Index));
        }

        // Get : Personen/ Delete/1
        public async Task<IActionResult>Delete(int Id)
        {
            var personDetails = await _service.GetByIdAsync(Id);

            if (personDetails == null) return View("nicht gefunden");


            return View(personDetails);
        }


        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var personDetails = await _service.GetByIdAsync(Id);

            if (personDetails == null) return View("nicht gefunden");

            await _service.DeleteAsync(Id);

            return RedirectToAction(nameof(Index));
        }

        

    }
}

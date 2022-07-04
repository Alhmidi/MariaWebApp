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
    public class OrganenController : Controller
    {
        private readonly IOrganenService _service;

      

        public OrganenController(IOrganenService service)
        {
            _service = service;

        }

        public  async Task<IActionResult> Index()
            
        {
            var allOrganen = await _service.GetAllAsync();

            return View(allOrganen);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allOrganen = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allOrganen.Where
                (n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Land, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Strasse, searchString, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(n.Id.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                 return View("Index", filteredResultNew);
            }

             return View("Index", allOrganen);
        }


        //GET : Organen/Details/1
        public async Task<IActionResult>Details( int id)
        {
            var organDetials = await _service.GetByIdAsync(id);
            if (organDetials == null) return View("nicht gefunden");
            return View(organDetials);
            
        }
        // GET/ Organen /Create
        public IActionResult Create()
        {
            return View();     
        }


         // Create/ Organ
        [HttpPost]
        public async Task<IActionResult> Create([Bind()]Organ newOrgan)
        {
            if(!ModelState.IsValid)
            {
                return View(newOrgan);
            }
            await _service.AddAsync(newOrgan);
            return RedirectToAction(nameof(Index));
        }

        // GET/ Organen /edit/1
        public  async Task<IActionResult> Edit(int id)
        {
            var organDetials = await _service.GetByIdAsync(id);
            if (organDetials == null) return View(" nicht gefunden");
              return View(organDetials);
        }


        // Edit/ Organ
        [HttpPost]
        public async Task<IActionResult>Edit( int id ,[Bind()] Organ organ)
        {
            if (!ModelState.IsValid)
            {
                return View(organ);
            }
            if(id == organ.Id)
            {
                await _service.UpdateAsync(id, organ);
                return RedirectToAction(nameof(Index));
            }
            return View(organ);
            
        }
        // GET/ Organen /Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var organDetials = await _service.GetByIdAsync(id);
            if (organDetials == null) return View(" nicht gefunden");
            return View(organDetials);
        }


        // Delete/ Organ
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var organDetials = await _service.GetByIdAsync(id);
            if (organDetials == null) return View(" nicht gefunden");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }


    }
}

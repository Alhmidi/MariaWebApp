using MariaWebApp.Data;
using MariaWebApp.Data.Services;
using MariaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Controllers
{
    public class EinträgeController : Controller
    {
        private readonly IEinträgeService _service;

        public EinträgeController(IEinträgeService service)
        {
            _service = service;
        }
         
        public async Task<IActionResult> Index()
        {
            var allEinträge =  await _service.GetAllAsync();

            return View(allEinträge);
        }


        public async Task<IActionResult> Filter( string searchString)
        {
            var allEinträge = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
               
                var filteredResultNew = allEinträge.Where(n => string.Equals(n.Id.ToString(), searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.EintragInhalt, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

                return View("Index", allEinträge);
        }
    


        // Get :Eintrag /Create
        public async Task<IActionResult> Create()
        {
            var eintragDropdownsData = await _service.GetNewEintragDropdownsValues();
            ViewBag.Personen = new SelectList(eintragDropdownsData.Personen,"Id","Vorname"); // Or By Id state Vorname
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create( NewEintragVM eintrag)
        {
            if (!ModelState.IsValid)
            {
                var eintragDropdownsData = await _service.GetNewEintragDropdownsValues();
                ViewBag.Personen = new SelectList(eintragDropdownsData.Personen, "Id", "Vorname");
                return View(eintrag);
            }
            await _service.AddNewEintragAsync (eintrag);
            return RedirectToAction(nameof(Index));
        }


        //GET: Eintrag/Details/1
     
        public async Task<IActionResult>Details(int id)
        {
            var eintragDetails = await _service.GetEintragByIdAsync(id);
            return View(eintragDetails);
        }


        //Get : Eintrag /Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var eintragDetails = await _service.GetEintragByIdAsync(id);
            if (eintragDetails == null) return View("nicht gefunden");
            var response = new NewEintragVM()
            {
                Id = eintragDetails.Id,
                CreateDatetime = eintragDetails.CreateDatetime,
                EintragInhalt = eintragDetails.EintragInhalt,
                PersonIds = eintragDetails.Personen_Einträge.Select(n => n.PersonId).ToList(),
            };
              var eintragDropdownsData = await _service.GetNewEintragDropdownsValues();
              ViewBag.Personen = new SelectList(eintragDropdownsData.Personen, "Id", "Vorname");
              return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEintragVM eintrag)
        {
            if (id != eintrag.Id) return View("nicht gefunden");

            if (!ModelState.IsValid) 
            {
                var eintragDropdownsData = await _service.GetNewEintragDropdownsValues();
                ViewBag.Personen = new SelectList(eintragDropdownsData.Personen, "Id", "Vorname");

                return View(eintrag);
            }   
               await _service.UpdateEintraAsync(eintrag);
               return RedirectToAction(nameof(Index));
        }

        //Get: Einträge/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var EintragDetails = await _service.GetByIdAsync(id);
            if (EintragDetails == null) return View("NotFound");
            return View(EintragDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var EintragDetails = await _service.GetByIdAsync(id);
            if (EintragDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        /////////////////////////////////////////////////////////////



    }


}

using MariaWebApp.Data;
using MariaWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariaWebApp.Controllers
{
    public class Personen_EinträgeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Personen_EinträgeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Person_Eintrag.ToListAsync();

            return View(data);
        }

        

    }

}
